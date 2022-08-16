namespace Lesson_7
{
    /// <summary>
    /// Шифрование / дешифрование строк
    /// </summary>
    internal interface ICoder
    {
        /// <summary>
        /// Шифрование строки
        /// </summary>
        /// <param name="text">Строка для шифрования</param>
        /// <param name="alfabet">Алфавит для шифрования строк</param>
        /// <returns></returns>
        public string Encoder(string text, char[] alfabet);


        /// <summary>
        /// Шифрование строки
        /// </summary>
        /// <param name="text">Строка для дешифрования</param>
        /// <param name="alfabet">Алфавит для дешифрования строк</param>
        /// <returns></returns>
        public string Decoder(string text, char[] alfabet);
    }
}
