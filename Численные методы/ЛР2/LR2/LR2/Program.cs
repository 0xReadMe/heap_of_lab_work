int n = 3;
double[,] matrixA = new double[3, 3]
{
    {0.63, -0.37, 1.76},
    {0.9, 0.99,  0.05},
    {0.13, -0.95, 0.69}
};
double[] matrixB = { -9.29, 0.12, 0.69 };
double[] result = Gaus(matrixA, matrixB);
Console.WriteLine("Корни уравнений:");
for (int i = 0; i < n; i++)
{
    Console.WriteLine($"x{i} = {result[i]}");
}
Console.WriteLine("----------------------------------------");
Console.WriteLine("Вычисление обратной матрицы: ");
double[,] Y = MOBR(matrixA);
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        Console.Write($"{Y[i, j]:f4}  ");
    }
    Console.WriteLine(" ");
}
Console.WriteLine("----------------------------------------");
Console.WriteLine($"Детерминант матрицы - {Math.Round(DetermDemo(matrixA), 6)}");
Console.WriteLine($"Детерминант матрицы - {Determ(matrixA)}");


Console.WriteLine("----------------------------------------");
double[,] Arr = new double[3, 3]
{
    {0, 0.025641, 0.153846},
    {0.023256, 0,  0.046512},
    {0.166667, 0.611111, 0 }
};
double[] Arr1 = { 0.717949, -0.89535, -1.40278 };
double e = 0.0001;
double[] X0 = new double[Arr1.Length];
double[] X1 = new double[Arr1.Length];

if (Alpha3(Arr) < 1)
{
    double Alf = Alpha1(Arr);
    for (int i = 0; i < X1.Length; i++)
    {
        X1[i] = Arr1[i];
    }
    do
    {
        for (int i = 0; i < X1.Length; i++)
        {
            X0[i] = X1[i];
        }
        X1 = Iter(Arr, Arr1, X0);
    }
    while (Po1(X0, X1) > (e * (1 - Alf)) / Alf);
    for (int i = 0; i < X1.Length; i++)
    {
        Console.WriteLine($"x{i + 1} = {X1[i]}");
        
    }
}
if (Alpha2(Arr) < 1)
{
    for (int i = 0; i < X1.Length; i++)
    {
        X1[i] = Arr1[i];
    }
    do
    {
        for (int i = 0; i < X1.Length; i++)
        {
            X0[i] = X1[i];
        }
        X1 = Iter(Arr, Arr1, X0);
    }
    while (Po2(X0, X1) > (e * (1 - Alpha2(Arr))) / Alpha2(Arr));
    for (int i = 0; i < X1.Length; i++)
    {
        Console.WriteLine($"x{i + 1} = {X1[i]}");
        
    }
}
if (Alpha1(Arr) < 1)
{
    
    for (int i = 0; i < X1.Length; i++)
    {
        X1[i] = Arr1[i];
    }
    do
    {
        for (int i = 0; i < X1.Length; i++)
        {
            X0[i] = X1[i];
        }
        X1 = Iter(Arr, Arr1, X0);
    }
    while (Po3(X0, X1) > (e * (1 - Alpha3(Arr))) / Alpha3(Arr));
    for (int i = 0; i < X1.Length; i++)
    {
        Console.WriteLine($"x{i + 1} = {X1[i]}");
        Console.WriteLine("Сходится по евклидовой  метрике");
    }
    
}
else
    Console.WriteLine("Нет решения");
Console.ReadKey();

#region Итерации

static double[] Iter(double[,] Arr, double[] B, double[] X0)
{
    double[] temp = new double[B.Length];
    for(int i = 0; i < B.Length; i++)
    {
        double sum = 0;
        for(int j = 0; j < B.Length; j++)
        {
            sum += Arr[i, j] * X0[j];
        }
        temp[i] = sum + B[i];
    }
    return temp;
}
#endregion

#region Альфы
static double Alpha1(double[,] Arr)
{
    var n = Arr.GetLength(0);
    
    double max = 0;
    for (int i = 0; i < n; i++)
    {
        double a = 0;
        for (int j = 0; j < n; j++)
        {
            a += Math.Abs(Arr[i, j]);
        }
        if(a > max)
            max = a;
    }
    return max;
}

static double Alpha2(double[,] Arr)
{
    var n = Arr.GetLength(0);
    
    double max = 0;
    for (int j = 0; j < n; j++)
    {
        double a = 0;
        for (int i = 0; i < n; i++)
        {
            a += (Math.Abs(Arr[i, j]));
        }
        if (a > max)
            max = a;
    }
    return max;
}

static double Alpha3(double[,] Arr)
{
    var n = Arr.GetLength(0);
    double a = 0;
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            a += (Math.Pow(Arr[i, j], 2));
        }
    }
    return Math.Sqrt(a);
}
#endregion

#region Po
static double Po1(double[] X0, double[] X1)
{
    int n = X0.GetLength(0);
    double a = 0;
    double max = 0;
    for (int i = 0; i < n; i++)
    {
        a = Math.Abs(X0[i] - X1[i]);
        if (a > max)
            max = a;
    }
    return max;
}

static double Po2(double[] X0, double[] X1)
{
    int n = X0.GetLength(0);
    double a = 0;
    for (int i = 0; i < n; i++)
    {
        a += Math.Abs(X0[i] - X1[i]);
    }
    return a;
}

static double Po3(double[] X0, double[] X1)
{
    int n = X0.GetLength(0);
    double a = 0;
    for (int i = 0; i < n; i++)
    {
        a += Math.Pow(X0[i] - X1[i], 2);
    }
    return Math.Sqrt(a);
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

#region  Детерминанты

static double[,] GausTwo(double[,] A1)
{
    int n = 3;
    double[,] A = new double[n, n];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            A[i, j] = A1[i, j];
        }
    }
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
        }
    }
    return A;
}
static double Determ(double[,] matrix)
{
    double det = 1;

    var A = GausTwo(matrix);
    int Rank = A.GetLength(0);
    for (int i = 0; i < Rank; i++)
    {
        for (int j = 0; j < Rank; j++)
        {
            if (i == j)
            {
                det *= A[i, j];
            }
        }
    }
    return det;
}
static double DetermDemo(double[,] matrix)
{
    return matrix[0, 0] * matrix[1, 1] * matrix[2, 2] +
           matrix[0, 1] * matrix[1, 2] * matrix[2, 0] +
           matrix[0, 2] * matrix[2, 1] * matrix[1, 0] -
           matrix[0, 2] * matrix[1, 1] * matrix[2, 0] -
           matrix[0, 1] * matrix[2, 2] * matrix[1, 0] -
           matrix[0, 0] * matrix[1, 2] * matrix[2, 1];
}
#endregion