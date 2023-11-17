using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Rectangle : Figure
    {
        static string name = "Rectangle";

        public Rectangle() 
        {
            
        }
        public Rectangle(double a, double b) : base(a, b)
        {
            
        }

        public double Square(double a, double b) => a * b;

        public double Perimetr(double a, double b) => (a + b) * 2;

        public void PrintInfo() 
        {
            Console.WriteLine(
                $"Имя фигуры: {name}\n" +
                $"Площадь: {Square(this.a, this.b)}\n" +
                $"Периметр: {Perimetr(this.a, this.b)}\n"
                );
        }
    }
}
