using System;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {        
            Console.WriteLine("Придумайте имя студенту");
            string Name = Console.ReadLine();
            Console.WriteLine("На каком курсе учится студент?");
            int Course = int.Parse(Console.ReadLine());
            Console.WriteLine("Какой средний балл студента?");
            double Eveluations = double.Parse(Console.ReadLine());
            Student student1 = new Student(Name, Course, Eveluations);
            Console.WriteLine("Данные о студенте");
            Console.WriteLine($"Студент по имени: {student1.Name} учится на курсе № {student1.Course}, имеет средний балл {student1.Eveluations} и получает степендию в размере {student1.Scholarship} рублей");
           

            Console.WriteLine("Придумайте имя студенту");
            string Name2 = Console.ReadLine();
            Console.WriteLine("Какая степендя у студента?");
            double Scholarship = double.Parse(Console.ReadLine());
            Student student2 = new Student(Name2, Scholarship);
            


            Console.WriteLine("Придумайте имя студенту");
            string Name3 = Console.ReadLine();
            Student student3 = new Student(Name3);
            Console.ReadLine();
            Console.ReadKey();
        }
    }
}
