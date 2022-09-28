// Задача 58: Задайте две матрицы. Напишите программу,
// которая будет находить произведение двух матриц.
// Например, заданы 2 массива:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// и
// 1 5 8 5
// 4 9 4 2
// 7 2 2 6
// 2 3 4 7
// Их произведение будет равно следующему массиву:
// 1 20 56 10
// 20 81 8 6
// 56 8 4 24
// 10 6 24 49

int ReadNumber(string message) // метод ввода числа
{
    Console.WriteLine(message);
    return Convert.ToInt32(Console.ReadLine());
}

// метод создания двумерного массив (матрицы) 
int[,] GetMatrix(int rowsCount, int columnsCount, int leftRange = 1, int rightRange = 10) // 1 и 10 значения по умолчанию
{
    int[,] matrix = new int[rowsCount, columnsCount];

    Random rand = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rand.Next(leftRange, rightRange + 1);
        }
    }
    return matrix;
}


// метод произведения элементов двух матриц
int[,] MultiplyMatrix(int[,] firstMartrix, int[,] secomdMartrix)
{
    int[,] resultMatrix = new int[secomdMartrix.GetLength(0), secomdMartrix.GetLength(1)];
    for (int i = 0; i < resultMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < resultMatrix.GetLength(1); j++)
        {
            resultMatrix[i, j] = firstMartrix[i, j] * secomdMartrix[i, j];
        }
    }
    return resultMatrix;
}

// метод печати двумерного массива (матрицы) на экран
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}
Console.WriteLine();
Console.WriteLine("Создадим две матрицы:");
int m = ReadNumber("Введите количество строк для создваемых матриц");
int n = ReadNumber("Введите количество столбцов для создваемых матриц");
int[,] firstMartrix = GetMatrix(m, n);
PrintMatrix(firstMartrix);
Console.WriteLine();
int[,] secomdMartrix = GetMatrix(m, n);
PrintMatrix(secomdMartrix);
Console.WriteLine();
int[,] result = MultiplyMatrix(firstMartrix, secomdMartrix);
Console.WriteLine("Результат:");
PrintMatrix(result);
