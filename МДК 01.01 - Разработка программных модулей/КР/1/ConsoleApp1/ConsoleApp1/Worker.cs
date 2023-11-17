using System;

namespace ConsoleApp1
{
    class Worker
    {
        #region Поля
        string secondName = "";
        int day, month, year;
        string dob;
        int cash;
        #endregion

        #region Свойства
        public string SecondName{
            get
            {
                return secondName;
            }
            set
            {
                secondName = Convert.ToString(value);
            }
        }
        public int Day 
        {
            get 
            { 
                return day; 
            }
            set 
            {
                if (value > 0 && value <= 31)
                {
                    day = value;
                }
                else
                {
                    Console.WriteLine("Exception: Введен день меньше 0 или больше 31");
                }
            }
        }
        public int Month 
        {
            get
            {
                return month;
            }
            set
            {
                if (value > 0 && value <= 12)
                {
                    month = value;
                }
                else
                {
                    Console.WriteLine("Exception: Введен месяц меньше 0 или больше 12");
                }
            }
        }
        public int Year
        {
            get 
            { 
                return year; 
            }
            set 
            {
                if (value > 0)
                {
                    year = value;
                }
                else 
                {
                    Console.WriteLine("Exception: Введен год меньше 0");
                }
            }
        }

        public int Cash 
        {
            get 
            { 
                return cash; 
            }
            set
            {
                if (value > 0)
                {
                    cash = value;
                }
                else
                {
                    Console.WriteLine("Exception: Введен оклад меньше 0");
                }
            }
        }
        public string Dob 
        {
            get 
            {
                if (month < 10)
                {
                    return $"{day}.0{month}.{year}";
                }
                else 
                {
                    return $"{day}.{month}.{year}";
                }
            }
        }
        #endregion

        #region Конструкторы
        public Worker() 
        {
            Console.WriteLine("Создан класс рабочего без заданных параметров.");
        }

        public Worker(string secondName, int day, int month, int year, int cash)
        {
            SecondName = secondName;
            Day = day;
            Month = month;
            Year = year;
            Cash = cash;
        }
        #endregion

        #region Методы
        public int FindAge(int ourYear) 
        {
            return ourYear - Year;
        }

        public int FindAge50() 
        {
            int age = FindAge(2022);
            if (age > 50)
            {
                return 0;
            }
            else 
            {
                int yearsLeft = 50 - age;
                int daysLeft = yearsLeft * 365;
                return daysLeft;
            }

        }

        public void Information() 
        {
            Console.WriteLine($"Инфмормация о рабочем с фамилией {SecondName}:");
            Console.WriteLine($">Оклад: {Cash}");
            Console.WriteLine($">Дата рождения: {Dob}");
            Console.WriteLine($">Текущий возраст работника: {FindAge(2022)}");
            Console.WriteLine($">До 50 лет осталось дней: {FindAge50()}");
        }
        #endregion
    }
}
