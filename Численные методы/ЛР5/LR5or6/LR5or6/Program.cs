using static System.Console;
using static System.Math;
BackgroundColor = ConsoleColor.Black;
ForegroundColor = ConsoleColor.Green;

double[] X = {7.4, 10, 12.8, 20, 26, 32};
double[] Y = {16.3, 15.2, 14.5, 13.5, 13.1, 12.8};
double[] XY = new double[X.Length];
double[] X2 = new double[X.Length];
double[] X3 = new double[X.Length];
double[] X4 = new double[X.Length];
double[] Y8 = new double[X.Length];
for (int i = 0; i < X.Length; i++) 
{
    XY[i] = X[i] * Y[i];
    X2[i] = Pow(X[i], 2);
    X3[i] = Pow(X[i], 3);
    X4[i] = Pow(X[i], 4);
}
WriteLine("Линейная функция: ");
double a1 = (XY.Sum() * X.Length - Y.Sum() * X.Sum())/(X.Length * X2.Sum() - Pow(X.Sum(), 2));
double a0 = Y.Sum()/X.Length - a1 * X.Sum() / X.Length;
for (int i = 0; i < X.Length; i++)
{
    Y8[i] = a0 + a1 * X[i];
    WriteLine($"x{i+1} = {Y8[i]:f5}");
}    

double Mx = X.Sum()/X.Length;
double My = Y.Sum()/Y.Length;
double[] x_Mx = new double[X.Length];
double[] x_Mx2 = new double[X.Length];
double[] y_My = new double[X.Length];
double[] y_My2 = new double[X.Length];
double[] x_Mxy_My = new double[X.Length];
for (int i = 0; i < X.Length; i++)
{
    x_Mx    [i] = X[i] - Mx;
    x_Mx2   [i] = Pow(x_Mx[i], 2);
    y_My    [i] = Y[i] - My;
    y_My2   [i] = Pow(y_My[i], 2);
    x_Mxy_My[i] = x_Mx[i] * y_My[i];
}
double r = x_Mxy_My.Sum()/Sqrt(x_Mx2.Sum()* y_My2.Sum());
WriteLine($"Коэффициент корреляции - {r}");

double[,] matrixA = new double[3, 3]
{
    {X.Length,  X.Sum(),   X2.Sum()},
    {X.Sum(),   X2.Sum(),  X3.Sum()},
    {X2.Sum(),  X3.Sum(),  X4.Sum()}
};
double[] matrixB = { Y.Sum(), 20.673, 1719.661};
WriteLine("----------------------------------------"
   + "\nКвадратичная функция: "
   + "\nВычисление обратной матрицы: ");
double[,] mobr = MOBR(matrixA);
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Write($"{mobr[i, j]:f9}  ");
    }
    WriteLine(" ");
}
WriteLine("Правые части: ");
double[] multM = MatrixMultiplication(mobr, matrixB);
for (int i = 0; i < 3; i++)
    WriteLine($"a{i+1} = {multM[i]:f9}  ");
WriteLine("----------------------------------------");
for (int i = 0; i < X.Length; i++)
    WriteLine($"x{i + 1} = {multM[0] + multM[1] * X[i] + multM[2] * Pow(X[i], 2):f9}  "); 
ReadLine();


#region Поиск правых частей

static double[] MatrixMultiplication(double[,] matrixA, double[] matrixB)
{
    var matrixC = new double[matrixB.Length];
    for (var i = 0; i < matrixA.GetLength(0); i++)
    {
        for (var j = 0; j < matrixB.Length; j++)
        {
            matrixC[i] = 0;

            for (var k = 0; k < matrixA.GetLength(0); k++)
            {
                matrixC[i] += matrixA[i, k] * matrixB[k];
            }
        }
    }
    return matrixC;
}
#endregion

#region Метод Гаусса
static double[] Gaus(double[,] A1, double[] B)
{
    int n = B.Length;
    double[] x = new double[n];

    double[,] A = new double[n, n];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            A[i, j] = A1[i, j];
        }
    }
    double s = 0;
    double M = 0;
    for (int k = 0; k < n; k++)
    {
        for (int i = k + 1; i < n; i++)
        {
            M = A[i, k] / A[k, k];
            for (int j = k; j < n; j++)
            {
                A[i, j] = A[i, j] - A[k, j] * M;
            }
            B[i] = B[i] - B[k] * M;
        }
    }
    for (int k = n - 1; k >= 0; k--)
    {
        s = 0;
        for (int j = k + 1; j < n; j++)
        {
            s = s + A[k, j] * x[j];
        }
        x[k] = (B[k] - s) / A[k, k];
    }
    return x;
}
#endregion

#region Вычисление обратной матрицы
static double[,] MOBR(double[,] A)
{
    int n = A.GetLength(0);
    double[] B = new double[n];
    double[] x = new double[n];
    double[,] y = new double[n, n];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (i == j)
            {
                B[j] = 1;
            }
            else
            {
                B[j] = 0;
            }
        }
        x = Gaus(A, B);
        for (int j = 0; j < n; j++)
        {
            y[j, i] = x[j];
        }
    }
    return y;
}
#endregion