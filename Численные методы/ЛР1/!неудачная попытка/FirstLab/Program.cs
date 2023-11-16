using System;

namespace FirstLab
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const double e = 0.0001; //Точность

            Console.WriteLine("Введите верхнюю границу: ");
            Console.Write(">");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите нижнюю границу:");
            Console.Write(">");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите шаг:");
            Console.Write(">");
            double h = double.Parse(Console.ReadLine());

            for (double x = a; x < b; x += h) 
            {
                if (Function(x) * Function(x + h) < 0) 
                {
                    Console.WriteLine($"Нашли смену знака на промежутке [{x:f4};{x+h:f4}]");
                    DichotomyMethod(x, x + h, e);
                    NewtonTangent(x, x + h, e);
                    NewtonChords(x, x + h, e);
                }
            }
            Console.ReadLine();
        }

        #region Методы расчета фукции и производных

        //Метод для расчёта функции
        static double Function(double x) => 3 * Math.Sin(x) - x + 0.9;

        //Метод для поиска производной первого порядка
        static double DerivativeFirst(double x) => (-10 * Math.Sin(x)) - 0.2 * x;

        //Метод для поиска производной второго порядка
        static double DerivativeSecond(double x) => -10 * Math.Cos(x) - 0.2;
        #endregion

        #region Метод дихотомии
        static void DichotomyMethod(double a, double b, double e)
        // Метод для поиска приближённого значения методом половинного деления
        {
            int n = 0; // переменная для подсчёта итераций
            double c = 0; // середина отрезка
            double fC = 0; // переменная для вычисления функции середины отрезка
            double fA = 0; // переменная для вычисления функции границы отрезка
            do
            {
                c = (b + a) / 2; // нахождение середины отрезка
                fC = Function(c);
                fA = Function(a);
                n++;
                if(Math.Abs(fC) < e) // проверка точности
                    break;
                if (fA * fC > 0) 
                    a = c; // сдвиг границы
                else 
                    b = c; // сдвиг границы
            } while (Math.Abs(b - a) > e);
            Console.WriteLine($"x = {c:f4} F(x) = {fC:f4} Количество итераций = {n}");
        }
        #endregion

        #region Метод касательных
        static void NewtonTangent(double x1, double x2, double e)
        // Метод Ньютона (касательные)
        {
            double x_next = 0;
            int k = 0;
            if (DerivativeFirst((x1 + x2) / 2) * DerivativeSecond((x1 + x2) / 2) < 0)
            {
                do
                {
                    x_next = x1 - (Function(x1) / DerivativeFirst(x1));
                    x1 = x_next;
                    k++;
                } while (Math.Abs(x1 - x_next) > e);
            }
            else if (DerivativeFirst((x1 + x2) / 2) * DerivativeSecond((x1 + x2) / 2) > 0)
            {
                do
                {
                    x_next = x2 - (Function(x2) / DerivativeFirst(x2));
                    x2 = x_next;
                    k++;
                } while (Math.Abs(x2 - x_next) > e);
            }
            Console.WriteLine($"x = {x_next:f4} F(x) = {Function(x_next):f4} Количество итераций = {k} ");
        }
        #endregion

        #region Метод хорд
        
        static void  NewtonChords(double x1, double x2, double e)
        // Метод для поиска приближённого значения методом Ньютона (хорды)
        // x1 - Xn-1
        // x2 - Xn
        {
            int k = 0; // Переменная для подсчёта итераций
            double x_next = 0; // Xn+1
            double tmp = 0;
            if (DerivativeFirst((x1 + x2) / 2) * DerivativeSecond((x1 + x2) / 2) < 0)
            {
                do
                {
                    tmp = x_next;
                    x_next = x2 - ((Function(x2) * (x2 - x1)) / (Function(x2) - Function(x1)));
                    x1 = x2;
                    x2 = tmp;
                    k++;
                }while (Math.Abs(x_next - x2) > e);

            }
            else if (DerivativeFirst((x1 + x2) / 2) * DerivativeSecond((x1 + x2) / 2) > 0)
            {
                do
                {
                    tmp = x_next;
                    x_next = x1 - ((Function(x1) * (x2 - x1)) / (Function(x2) - Function(x1)));
                    x1 = x2;
                    x2 = tmp;
                    k++;
                } while (Math.Abs(x_next - x2) > e);
            }
            
            Console.WriteLine($"x = {x_next:f4} F(x) = {Function(x_next):f4} Количество итераций = {k} ");
        }
        #endregion
    }
}