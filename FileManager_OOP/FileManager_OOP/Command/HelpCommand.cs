using FileManager.Commands.Base;

namespace FileManager.Commands;

public class HelpCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;

    public override string Description => "Help";

    public HelpCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }

    public override void Execute(string[] args)
    {
        _UserInterface.WriteLine("The file manager supports the following commands:");

        foreach (var (name, command) in _FileManager.Commands)
            _UserInterface.WriteLine($"    {name}\t{command.Description}");
    }
}
