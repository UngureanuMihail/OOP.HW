using FileManager.Commands.Base;

namespace FileManager.Commands;

public class PrintDirectoryFilesCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;

    public override string Description => "Listing the contents of a directory";

    public PrintDirectoryFilesCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }

    public override void Execute(string[] args)
    {
        var directory = _FileManager.CurrentDirectory;
        _UserInterface.WriteLine($"Directory content {directory}:");

        var dirs_count = 0;
        foreach (var sub_dir in directory.EnumerateDirectories())
        {
            _UserInterface.WriteLine($"    d    {sub_dir.Name}");
            dirs_count++;
        }

        var files_count = 0;
        long total_length = 0;
        foreach (var file in directory.EnumerateFiles())
        {
            _UserInterface.WriteLine($"    f    {file.Name}\t{file.Length}");
            files_count++;
            total_length += file.Length;
        }

        _UserInterface.WriteLine("");
        _UserInterface.WriteLine($"Directory {dirs_count}, files {files_count} (total size {total_length} bytes)");
    }
}
