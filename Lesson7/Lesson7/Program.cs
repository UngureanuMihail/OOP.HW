using Lesson_7;

///Определение алфавита
char[] alfabet = Enumerable.Range('a', 26).Select(x => (char)x).ToArray();


Console.WriteLine("Choose your program:\nPress 1: To encode text by changing the symbols to the next one\n" +
    "Press 2: To econde text by changing the symbols to the reversed one  ");
int number = int.Parse(Console.ReadLine());


Console.WriteLine("Introduce your text : ");
string text = Console.ReadLine().ToLower();


ACode ACode = new();
BCode BCode = new();


///Возможность выбора метода шифрования
switch (number)
{
    case 1:
        text = ACode.Encoder(text, alfabet);
        Console.WriteLine($"Your encoded text is : {text}");
        text = ACode.Decoder(text, alfabet);
        Console.WriteLine($"Your decoded text is : {text}");
        break;
    case 2:
        text = BCode.Encoder(text, alfabet);
        Console.WriteLine($"Your encoded text is : {text}");
        text = BCode.Decoder(text, alfabet);
        Console.WriteLine($"Your decoded text is : {text}");
        break;
    default:
        break;
}
