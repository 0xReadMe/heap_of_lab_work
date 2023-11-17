using System;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s;
            string[] s2;
            string path = "C:/Users/8-bit/Desktop/3к/0101/ЛР4/ConsoleApp1";
            Random rnd = new Random();

            Console.WriteLine("Введите букву: ");
            Console.Write(">");
            var sym = Convert.ToChar(Console.ReadLine());
            FileFillSymbols(rnd, path + "/f.txt", false);
            using StreamReader file1 = new StreamReader(path + "/f.txt");
            s = FileClear(file1);
            file1.Close();
            using StreamWriter fileOut = new StreamWriter(path + "/output.txt", false);
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (sym == Convert.ToChar(s[i]))
                {
                    fileOut.Write($"{s[i - 1]}, ");
                }
            }
            Console.Write($"Произошла запись в файлы");
        }
        static string[] FileClear(StreamReader fileIn)
        {
            string line = fileIn.ReadToEnd();
            StringBuilder a = new StringBuilder(line);
            for (int i = 0; i < a.Length;)
            {
                if (char.IsWhiteSpace(a[i]))
                {
                    a[i] = ' ';
                }
                //if (char.IsPunctuation(a[i]))
                //{
                //    a.Remove(i, 1);
                //}
                ++i;
            }
            string[] s = a.ToString().Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return s;
        }
        static void FileFillNumbers(Random rnd, string path, bool append)
        {
            using StreamWriter fileOut = new StreamWriter(path, append);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    fileOut.Write(rnd.Next(-100, 100) + " ");
                }
                fileOut.WriteLine();
            }
            fileOut.Close();
        }
        static void FileFillEvenNumbers(Random rnd, string path, bool append)
        {
            using StreamWriter fileOut = new StreamWriter(path, append);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    var a = rnd.Next(-100, 100);
                    if (a % 2 == 0)
                    {
                        fileOut.Write(a + " ");
                    }
                    else 
                    {
                        j--;
                    }
                    
                }
                fileOut.WriteLine();
            }
            fileOut.Close();
        }
        static void FileFillSymbols(Random rnd, string path, bool append)
        {
            using StreamWriter fileOut = new StreamWriter(path, append);
            string[] arrChar = new string[4] { "a", "b", "q", "h" };
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    int rndSym = rnd.Next(0, 3);
                    fileOut.Write(arrChar[rndSym] + " ");
                }
                fileOut.WriteLine();
            }
            fileOut.Close();
        }
        static void FileFillPunctuation(Random rnd, string path, bool append)
        {
            using StreamWriter fileOut = new StreamWriter(path, append);
            char[] arrPunctuation = new char[4] { '!', ',', '.', ':' };
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    int rndSym = rnd.Next(0, 3);
                    fileOut.Write(arrPunctuation[rndSym] + " ");
                }
                fileOut.WriteLine();
            }
            fileOut.Close();
        }
    }
}
