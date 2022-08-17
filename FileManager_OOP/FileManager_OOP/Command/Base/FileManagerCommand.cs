namespace FileManager.Commands.Base;

public abstract class FileManagerCommand
{

    public abstract string Description { get; }
  
    /// <summary>
    /// Метод для выполнение команд
    /// </summary>
    /// <param name="args"></param>
    public abstract void Execute(string[] args);
}
