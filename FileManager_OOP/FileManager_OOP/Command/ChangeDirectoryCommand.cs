using FileManager.Commands.Base;

namespace FileManager.Commands;

public class ChangeDirectoryCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;
    public override string Description => "To change the current directory";

    public ChangeDirectoryCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }

    public override void Execute(string[] args)
    {
        if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))
        {
            _UserInterface.WriteLine("For the change directory command, you must specify one parameter - the target directory");
            return;
        }

        var dir_path = args[1];

        DirectoryInfo? directory;

        if (dir_path == "..")
        {
            directory = _FileManager.CurrentDirectory.Parent;
            if (directory is null)
            {
                _UserInterface.WriteLine("Unable to climb up the directory tree");
                return;
            }
        }
        else if (!Path.IsPathRooted(dir_path))
            dir_path = Path.Combine(_FileManager.CurrentDirectory.FullName, dir_path);
        directory = new DirectoryInfo(dir_path);

        if (!directory.Exists)
        {
            _UserInterface.WriteLine($"Directory {directory} does not exist");
            return;
        }

        _FileManager.CurrentDirectory = directory;

        _UserInterface.WriteLine($"Current directory changed to {directory.FullName}");

        Directory.SetCurrentDirectory(directory.FullName);
    }
}