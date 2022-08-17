using FileManager.Commands;
using FileManager.Commands.Base;

namespace FileManager;
/// <summary>
/// Класс для описания логики файлового менеджера
/// </summary>
public class FileManagerLogic
{
    private bool _CanWork = true;

    private readonly IUserInterface _UserInterface;

    /// <summary>
    /// Текущая директория
    /// </summary>
    public DirectoryInfo CurrentDirectory { get; set; } = new("c:\\");

    /// <summary>
    /// Использование интерсфейса для словаря
    /// </summary>
    public IReadOnlyDictionary<string, FileManagerCommand> Commands { get; }

    public FileManagerLogic(IUserInterface UserInterface)
    {
        _UserInterface = UserInterface;

        var list_dir_command = new PrintDirectoryFilesCommand(UserInterface, this);
        var help_command = new HelpCommand(UserInterface, this);
        var quit_command = new QuitCommand(this);

        ///Словарь команд (ключи - по которым будут использоваться команды)
        Commands = new Dictionary<string, FileManagerCommand>
        {
            {"drives", new ListDrivesCommand(UserInterface) },
            {"listdir", list_dir_command },
            {"help", help_command },
            {"exit", quit_command },
            {"cd",  new ChangeDirectoryCommand(UserInterface, this) },
            {"del", new DeleteCommand(UserInterface, this) },
            {"move", new MoveCommand(UserInterface, this) },
            { "fs", new FileInformation(UserInterface, this) },
            { "cp", new CopyCommand(UserInterface, this) },

        };
    }

    public void Start()
    {
        _UserInterface.WriteLine("FileManager v.0\nTo show commands type 'help'");
        do
        {
            var input = _UserInterface.ReadLine("> ", false);

            var args = input.Split(' ');
            var command_name = args[0];

            if (!Commands.TryGetValue(command_name, out var command))
            {
                _UserInterface.WriteLine($"Unknown command {command_name}.");
                _UserInterface.WriteLine("-Type 'help' - to see the commands \nType 'exit' to quit the program");
                continue;
            }

            try
            {
                command.Execute(args/*[1..]*/);
            }
            catch (Exception error)
            {
                _UserInterface.WriteLine($"An error occurred while executing the command {command_name}");
                _UserInterface.WriteLine(error.Message);
            }
        }
        while (_CanWork);


        _UserInterface.WriteLine("The file manager is shooting down.");
    }

    public void Stop()
    {
        _CanWork = false;
    }
}
