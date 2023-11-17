using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===Инициализация новых экземпляров класса Worker (константные значения)===");
            InitClassConst();
            Console.WriteLine();
            Console.WriteLine("===Инициализация нового экземпляра класса Worker (с клавиатуры)===");
            Console.WriteLine("Введите день (1, 2, 3..) рождения рабочего:");
            Console.Write(">");
            int day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите месяц (1, 2, 3..) рождения рабочего:");
            Console.Write(">");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите год (1990, 1995, 2000..) рождения рабочего:");
            Console.Write(">");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите оклад рабочего:");
            Console.Write(">");
            int cash = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите фамилию рабочего:");
            Console.Write(">");
            string secondName = Console.ReadLine();
            Console.WriteLine();
            InitClassKeyboard(day, month, year, cash, secondName);
        }

        #region Инициализаторы классов для задания
        static void InitClassConst() 
        {
            // Конструктор по умолчанию
            Worker worker = new Worker();

            // Конструктор со значениями константами
            Worker worker1 = new Worker("Лавров", 19, 1, 2000, 35000);
            worker1.Information();
        }

        static void InitClassKeyboard(int day, int month, int year, int cash, string secondName) 
        {
            // Конструктор со значениями, введенными с клавиатуры
            Worker worker2 = new Worker(secondName, day, month, year, cash);
            worker2.Information();
        }
        #endregion
    }
}
