namespace FileManager;

public interface IUserInterface
{
    void WriteLine(string str);
    void Write(string str);

    /// <summary>
    /// Чтение строки с интерфейса пользователя
    /// </summary>
    /// <param name="Prompt"></param>
    /// <returns></returns>
    string ReadLine(string? Prompt, bool PromptNewLine = true);

    /// <summary>
    /// Чтение целых чисел
    /// </summary>
    /// <param name="Prompt"></param>
    /// <param name="PromptNewLine"></param>
    /// <returns></returns>
    int ReadInt(string? Prompt, bool PromptNewLine = true);

    /// <summary>
    /// Чтение чисел типа Double
    /// </summary>
    /// <param name="Prompt"></param>
    /// <param name="PromptNewLine"></param>
    /// <returns></returns>
    double ReadDouble(string? Prompt, bool PromptNewLine = true);
}
