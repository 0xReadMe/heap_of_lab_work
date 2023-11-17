using System;

namespace ConsoleApp1 
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Класс Point ");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Point p = new Point(10, 5); //(1)
            Console.WriteLine($"[{p.x};{p.y}]");
            Point p2= new Point(15, 10); //(2)
            Console.WriteLine($"[{p.x};{p.y}]");
            Line l = new Line(p, p2);
            Console.WriteLine("Класс Line");
            Console.WriteLine($"[{l.start.x}; {l.start.y}] ");
            Console.WriteLine($"[{l.end.x}; {l.end.y}]");
            Point p3 = new Point(0, 0); //(3)
            Point p4 = new Point(10, 0); 
            Point p5 = new Point(10, 5); 
            Point p6 = new Point(0, 5); 
            Line a1 = new Line(p3, p4);
            Line a2 = new Line(p4, p5);
            Line b1 = new Line(p5, p6);
            Line b2 = new Line(p6, p3);
            Rectangle r = new Rectangle(a1, a2, b1, b2);
            Console.WriteLine("Класс Rectangle");
            Console.WriteLine($"[{r.a1.start.x};{r.a1.start.y}] ; [{r.a1.end.x};{r.a1.end.y}]");
            Console.WriteLine($"[{r.a2.start.x};{r.a2.start.y}] ; [{r.a2.end.x};{r.a2.end.y}]");
            Console.WriteLine($"[{r.b1.start.x};{r.b1.start.y}] ; [{r.b1.end.x};{r.b1.end.y}]");
            Console.WriteLine($"[{r.b2.start.x};{r.b2.start.y}] ; [{r.b2.end.x};{r.b2.end.y}]");         
            Console.Write(" ");
            
            // рисование прямоугольника
            for (int i = 0; i < r.b1.start.x+r.b1.end.x; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine();
            for (int i = 0; i < r.b1.start.y + r.b2.end.y; i++)
            {
                Console.Write("|");
                for (int i1 = 0; i1 < r.b1.start.x + r.b1.end.x; i1++)
                {
                    Console.Write(" ");
                    
                }
                Console.WriteLine("|");
            }
            Console.Write(" ");
            for (int i = 0; i < r.b1.start.x + r.b1.end.x; i++)
            {
                Console.Write("‾");
            }
            // рисование прямоугольника

            Point p10 = new Point(0, 5);
            Line a = new Line(p3, p4);
            Line b = new Line(p4, p5);
            Elips elips = new Elips(a, b, p10);
            Console.WriteLine("Класс Elips");
        }
    }   
}

