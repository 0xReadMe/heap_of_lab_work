using System;

namespace ConsoleApp2
{
    class Triangle : Figure
    {
        static string name = "Triangle";
        double h;
        double c;

        public Triangle()
        {

        }
        public Triangle(double a, double b, double c, double h) : base(a, b)
        {
            this.h = h;
            this.c = c;
        }

        public double Square(double a, double h) => 0.5 * a * h;

        public double Perimetr(double a, double b, double c) => a + b + c;

        public void PrintInfo()
        {
            Console.WriteLine(
                $"Имя фигуры: {name}\n" +
                $"Площадь: {Square(a, h)}\n" +
                $"Периметр: {Perimetr(a, b, c)}\n"
                );
        }
    }
}
