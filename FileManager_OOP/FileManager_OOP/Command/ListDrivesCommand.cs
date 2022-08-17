using FileManager.Commands.Base;

namespace FileManager.Commands;

public class ListDrivesCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;

    public override string Description => "To show the list of disks";

    public ListDrivesCommand(IUserInterface UserInterface) => _UserInterface = UserInterface;

    /// <summary>
    /// Реализация метода Execute
    /// </summary>
    /// <param name="args"></param>
    public override void Execute(string[] args)
    {
        ///Получеине дисков
        var drives = DriveInfo.GetDrives();

        _UserInterface.WriteLine($"In your file system exists disks: {drives.Length}");

        ///
        foreach (var drive in drives)
            _UserInterface.WriteLine($"    {drive.Name}");
    }
}
