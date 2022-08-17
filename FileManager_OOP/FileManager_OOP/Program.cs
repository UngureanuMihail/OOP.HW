using FileManager;

var console_ui = new ConsoleUserInterface();

///Создание объекта файлового менеджера
var manager = new FileManagerLogic(console_ui);

///Запуск файлового менеджера
manager.Start();

Console.WriteLine("End");
Console.ReadLine();
