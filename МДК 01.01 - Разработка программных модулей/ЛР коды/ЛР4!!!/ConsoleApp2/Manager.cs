using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Manager : Person
    {
        string company;
        double sale;
        double prize;

        public string Company 
        {
            get => company;
            set => company = value;
        }

        public double Sale 
        {
            get => sale; 
            set => sale = value;
        }

        public double Prize 
        {
            get => prize;
            set 
            {
                prize = 0.05 * sale;
            } 
        }

        public Manager(string fam, int tab, int salary, string company, int sale) : base(fam, tab, salary) 
        {
            Company = company;
            Sale = sale;
            Prize = 0;
        }

        public void PrintInfo() 
        {
            Console.WriteLine(
                $"Информация о сотруднике {Fam}:\n"+
                $"--> Табельный номер: {Tab}\n" +
                $"--> Зарплата: {Salary}\n" +
                $"--> Компания: {Company}\n" +
                $"--> Объем продаж: {Sale}\n" +
                $"--> Премия: {Prize}\n"
                );
        }
    }
}
