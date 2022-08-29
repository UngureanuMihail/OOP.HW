using System.Text;

namespace Lesson_7
{
    /// <summary>
    /// Класс, созданный для шифрования строки путём замена символа на следующий символ алфавита
    /// </summary>
    internal class ACode : ICoder
    {
        /// <summary>
        /// Шифрование строки
        /// </summary>
        /// <param name="text">Строка для шифрования</param>
        /// <param name="alfabet">Алфавит для шифрования строк</param>
        /// <returns></returns>
        public string Encoder(string text, char[] alfabet)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var result = text.ToCharArray();
            char charToAppend = ' ';

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i].Equals(' '))
                    stringBuilder.Append(' ');

                for (int j = 0; j < alfabet.Length; j++)
                {
                    if (result[i] == alfabet[j])
                    {
                        if (j == alfabet.Length - 1)
                        {
                            charToAppend = alfabet[0];
                        }
                        else
                        {
                            charToAppend = alfabet[j + 1];
                        }
                        stringBuilder.Append(charToAppend);
                    }
                }
            }
            return stringBuilder.ToString();
        }


        /// <summary>
        /// Дешифрование строки
        /// </summary>
        /// <param name="text">Строка для дешифрования</param>
        /// <param name="alfabet">Алфавит для дешифрования строк</param>
        /// <returns></returns>
        public string Decoder(string text, char[] alfabet)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var result = text.ToCharArray();
            char charToAppend = ' ';

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i].Equals(' '))
                    stringBuilder.Append(' ');

                for (int j = 0; j < alfabet.Length; j++)
                {
                    if (result[i] == alfabet[j])
                    {
                        if (j == 0)
                        {
                            charToAppend = alfabet[alfabet.Length - 1];
                        }
                        else
                        {
                            charToAppend = alfabet[j - 1];
                        }
                        stringBuilder.Append(charToAppend);
                    }
                }
            }
            return stringBuilder.ToString();
        }

    }
}
