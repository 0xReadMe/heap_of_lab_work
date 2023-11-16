using static System.Math;
const double e = 0.0001;
Console.Write("Введите b - ");
double a = double.Parse(Console.ReadLine());
Console.Write("Введите a - ");
double b = double.Parse(Console.ReadLine());
int i = 0;
double n = 50;
double S0;
double S1 = MetRectangle(a, b, n);
do
{
    S0 = S1;
    n = n * 2;
    S1 = MetRectangle(a, b, n);
    i++;
} while (Abs(S0 - S1) > e);

Console.WriteLine($"Метод прямоугольников \n" +
    $"F(x) = {S1} \n" +
    $"Количество итераций - {i} \n" +
    $"n = {n}");

i = 0;
n = 50;
S1 = MetTrapezoid(a, b, n);
do
{
    S0 = S1;
    n = n * 2;
    S1 = MetTrapezoid(a, b, n);
    i++;
} while (Abs(S0 - S1) > e);

Console.WriteLine($"Метод трапеции \n" +
    $"F(x) = {S1} \n" +
    $"Количество итераций - {i} \n" +
    $"n = {n}");

i = 0;
n = 50;
S1 = MetSimpson(a, b, n);
do
{
    S0 = S1;
    n = n * 2;
    S1 = MetSimpson(a, b, n);
    i++;
} while (Abs(S0 - S1) > e);

Console.WriteLine($"Метод Симпсона \n" +
    $"F(x) = {S1} \n" +
    $"Количество итераций - {i} \n" +
    $"n = {n}");


#region Метод прямоугольника
static double MetRectangle(double a, double b, double n)
{
    double x;
    double S = 0;
    double h = (b - a) / n;
    for (int i = 0; i <= n - 1; i++)
    {
        x = a + i * h;
        S = S + F(x);
    }
    return S *= h;
}
#endregion

#region Метод трапеции
static double MetTrapezoid(double a, double b, double n)
{
    double h = (b - a) / n;
    double x;
    double xi;
    double S = 0;
    for (int i = 1; i <= n - 1; i++)
    {
        x = a + i * h;
        xi = a + (i + 1) * h;
        S += F(x) + F(xi);
    }
    return S * h / 2;
}
#endregion

#region Метод Симпсона
static double MetSimpson(double a, double b, double n)
{
    double h = (b - a) / n;
    double x;
    double p = 4;
    double S = 0;
    for (int i = 1; i <= n - 1; i++)
    {
        x = a + i * h;
        S += p * F(x);
        p = 6 - p;
    }
    return h / 3 * S;
}
#endregion

#region Вычисление функции
static double F(double x)
{
    return Sin(0.2 * x - 3) / (Pow(x, 2) + 1);
}
#endregion