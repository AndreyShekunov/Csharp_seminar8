// Задача 55: Задайте двумерный массив. Напишите программу,
// которая заменяет строки на столбцы.

int ReadNumber(string message) // метод ввода числа
{
    Console.WriteLine(message);
    return Convert.ToInt32(Console.ReadLine());
}

// метод создания двумерного массив (матрицы) 
int[,] GetMatrix(int rowsCount, int columnsCount, int leftRange = -10, int rightRange = 10) // - 10 и 10 значения по умолчанию
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


// метод замены строк на столбцы в двумерном массиве
int[,] ReplaceRowsWithColumns(int[,] matrix)
{
    int[,] matr = new int[matrix.GetLength(1), matrix.GetLength(0)];
    
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matr[j,i] = matrix[i,j];
        }
    }
    return matr;
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

int m = ReadNumber("Введите количество строк");
int n = ReadNumber("Введите количество столбцов");
int[,] matr = GetMatrix(m, n);
PrintMatrix(matr);
int[,] matrNew = ReplaceRowsWithColumns(matr);
Console.WriteLine();
PrintMatrix(matrNew);