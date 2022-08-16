using System.Text;

namespace Lesson_7
{
    /// <summary>
    /// Класс, созданный для шифрования строки путём замена символа на символ с обратной позицией
    /// </summary>
    internal class BCode : ICoder
    {
        /// <summary>
        /// Шифрование строки
        /// </summary>
        /// <param name="text">Строка для шифрования</param>
        /// <param name="alfabet">Алфавит для шифрования строк</param>
        /// <returns></returns>
        public string Encoder(string text, char[] alfabet)
        {
            StringBuilder stringBuilder = new StringBuilder(text.Length);
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
                        charToAppend = alfabet[(alfabet.Length - 1) - j];
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
            return Encoder(text, alfabet);
        }
    }
}
