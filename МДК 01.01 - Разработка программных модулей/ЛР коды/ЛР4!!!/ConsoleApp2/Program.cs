using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var Manager1 = InitClass("Иван", 100400, 32000, "Аппл", 1000);
            //var Manager2 = InitClass("Авдотий", 200400, 35000, "Майкрософт", 2000);
            //var Manager3 = InitClass("Никита", 100401, 31000, "Аппл", 5000);
            //var Manager4 = InitClass("Андрей", 100402, 50000, "Аппл", 500);
            //var Manager5 = InitClass("Михаил", 100403, 30500, "Аппл", 400);

            //Manager1.PrintInfo();
            //Manager2.PrintInfo();
            //Manager3.PrintInfo();
            //Manager4.PrintInfo();
            //Manager5.PrintInfo();

            //List<Manager> managers = new List<Manager>();
            //managers.Add(Manager1);
            //managers.Add(Manager2);
            //managers.Add(Manager3);
            //managers.Add(Manager4);
            //managers.Add(Manager5);
            //FindManager(100500, managers);
            //FindManager(100400, managers);

            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine("Выберите какую фигуру посчитать (П - прямоугольник, Т - треугольник): ");
                var chose = Console.ReadLine();
                if (chose == "П") 
                {
                    Console.WriteLine("Введите a и b:");
                    var a = Convert.ToDouble(Console.ReadLine());
                    var b = Convert.ToDouble(Console.ReadLine());
                    var rectangle = new Rectangle(a, b);
                    rectangle.PrintInfo();
                }
                if (chose == "Т")
                {
                    Console.WriteLine("Введите a, b, c, h:");
                    var a = Convert.ToDouble(Console.ReadLine());
                    var b = Convert.ToDouble(Console.ReadLine());
                    var c = Convert.ToDouble(Console.ReadLine());
                    var h = Convert.ToDouble(Console.ReadLine());
                    var triangle = new Triangle(a, b, c, h);
                    triangle.PrintInfo();
                }
            }
        }

        //static Manager InitClass(string fam, int tab, int salary, string company, int sale) 
        //{
        //    return new Manager(fam, tab, salary, company, sale);
        //}

        //static void FindManager(int tab, List<Manager> managers)
        //{
        //    foreach (var item in managers)
        //    {
        //        if (item.Tab != tab)
        //        {
        //            Console.WriteLine("Такого менеджера не существует в данной компании");
        //            break;
        //        }
        //        else 
        //        {
        //            Console.Write($"Нашли менеджера с данным номером.\n");
        //            item.PrintInfo();
        //            break;
        //        }
        //    }
        //}

        //var wrk1 = new Worker("Коля");
        //var wrk2 = new Worker("Дима");
        //var headwrk = new HeadWorker("Игорь Андреевич");

        //headwrk.Work();
        //wrk2.Work();
        //wrk1.Work();

        //Random rnd = new Random();
        //wrk2.PrizeForWorker(rnd);
        //wrk2.PrintInfo();
        //headwrk.SetCash(headwrk);
    }
}
