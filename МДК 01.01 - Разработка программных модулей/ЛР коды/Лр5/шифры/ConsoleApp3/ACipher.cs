using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class ACipher : ICipher
    {
        public string Text { get; set; }
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        int j;
        int d; // Смещение

        public ACipher(string text) 
        {
            Text = text;
        }

        public string Decode(string text)
        {
            throw new NotImplementedException();
        }

        public string Encode(string text)
        {
            char[] chars = text.ToCharArray();
            char[] char_ = alphabet.ToCharArray();
            for (int i = 0; i < chars.Length; i++) 
            {
                // Ищем индекс буквы
                for (j = 0; j < char_.Length; j++)
                {
                    if (chars[i] == char_[j])
                    {
                        break;
                    }
                }

                if (j != 26) // Если j равно 26, значит символ не из алфавита
                {
                    int index = j; // Индекс буквы
                    d = index + 1; // Делаем смещение

                    // Проверяем, чтобы не вышли за пределы алфавита
                    if (d >= 26)
                    {
                        d -= 26;
                    }

                    chars[i] = char_[d]; // Меняем букву
                }
            }
            string outText = "";
            foreach (char c in chars)
                outText += c.ToString();
            return outText;

        }
        public string Encode()
        {
            char[] chars = Text.ToCharArray();
            char[] char_ = alphabet.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                // Ищем индекс буквы
                for (j = 0; j < char_.Length; j++)
                {
                    if (chars[i] == char_[j])
                    {
                        break;
                    }
                }

                if (j != 26) // Если j равно 26, значит символ не из алфавита
                {
                    int index = j; // Индекс буквы
                    d = index + 1; // Делаем смещение

                    // Проверяем, чтобы не вышли за пределы алфавита
                    if (d >= 26)
                    {
                        d -= 26;
                    }

                    chars[i] = char_[d]; // Меняем букву
                }
            }

            string outText = "";
            foreach (char c in chars)
                outText += c.ToString();
            return outText;
        }
    }
}
