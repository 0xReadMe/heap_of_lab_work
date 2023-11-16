double[] massX = { 2, 4, 5, 7 }; // Исходный массив Х
double[] massY = { 9, -3, 6, -2 }; // Исходный массив Y
double[] massA = MatrixDisaddiction(massX, massY); // Матрица разделенных разностей полинома Ньютона

/// <summary>
/// Консольный вывод
/// </summary>
Console.WriteLine("     X     |    Канонический полином    |    Метод Ньютона    |    Метод Лагранжа    ");
for (double x = -1; x <= 5; x += 0.1)
{
    Console.Write($"{null, 3} {x, -3:f1} {null,2} | {null, 2} {FindCanonicalPolinom(massX, massY, x), 15:f4} {null,7} | {null, 5} {NewtonPolynom(massX, massY, massA, x), 7:f4} {null,5} | {null,5} {PolynomLangrange(massX,  massY, x),7:f4}");
    Console.WriteLine(  );
}
Console.ReadKey();

#region Полином Лангранжа
static double PolynomLangrange(double[] massX, double[] massY, double x)
{
    int n = massX.Length;
    double polynom = 0;
    for (int i = 0; i < n; i++)
    {
        double L = 1;
        for (int j = 0; j < n; j++)
        {
            if (i != j)
                L *= (x - massX[j]) / (massX[i] - massX[j]);
        }
        polynom += massY[i] * L;
    }
    return polynom;
}
#endregion

#region Метод Ньютона
static double NewtonPolynom(double[] massX, double[] massY, double[] massA, double x)
{
    int n = massX.Length;
    massA[0] = massY[0];
    double polynom = 0;
    for (int i = 0; i < n; i++)
    // используем цикл for для вычисления полинома
    {
        double recursion = 1;
        for (int j = 0; j <= i - 1; j++)
            // используем цикл for для реализации рекурсии
            recursion *= x - massX[j];
        polynom += massA[i] * recursion;
    }
    return polynom;
}
#endregion

#region Матрица Разностей
static double[] MatrixDisaddiction(double[] massX, double[] massY)
///<summary>
/// Вычисление матрицы разделенных разностей полинома Ньютона
///</ summary>
{
    int n = massX.Length;
    double[] massA = new double[n];
    double[,] matrixDisaddiction = new double[n, n]; // объявление матрицы разделенных разностей
    for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
            // заполнение первого столбца из массива Y
            matrixDisaddiction[i, 0] = massY[i];
    for (int i = 1; i < n; i++)
    {
        for (int j = 1; j < n; j++)
        {
            if (i < j)
                // заполнение нулями поля, которые выше нужной диагонали
                matrixDisaddiction[i, j] = 0;
            else
                // вычисление коэфициентов
                matrixDisaddiction[i, j] = (matrixDisaddiction[i, j - 1] - matrixDisaddiction[j - 1, j - 1]) / (massX[i] - massX[j - 1]);
            if (i == j)
                // заполнение массива коэфициентов коэфициентами
                massA[i] = matrixDisaddiction[i, j];
        }
    }
    return massA;
}
#endregion

#region Канонические интерполирование полинома
static double FindCanonicalPolinom(double[] massX, double[] massY, double x)
{
    int n = massX.Length;
    double[,] matrixA = new double[n, n];
    double[] massA = new double[n];
    double polynom;
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            matrixA[i, j] = Math.Pow(massX[i], j);
        }
    }
    matrixA = MOBR(matrixA);
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            massA[i] += matrixA[i, j] * massY[j];
        }
    }
    polynom = 0;
    for (int i = 0; i < n; i++)
    {
        polynom += massA[i] * Math.Pow(x, i);
    }
    return polynom;
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

                 ////\\\\
             ////        \\\\
         ////                \\\\
      ///    Ч.И.С.Л.Е.Н.Н.Ы.Е   \\\
//    \\\       М.Е.Т.О.Д.Ы      ///
//       \\\\                ////  
//           \\\\        ////
//               \\\\////