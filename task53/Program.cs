// Задача 53: Задайте двумерный массив. Напишите программу,
// которая поменяет местами первую и последнюю строку массива.

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


// метод замены первой строки массива на последнюю строку массива
void SwapFirstAndLastLines(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        int temp = matrix[0,i]; 
        matrix[0,i] = matrix[matrix.GetLength(0) - 1, i]; 
        matrix[matrix.GetLength(0) - 1, i] = temp;
    }
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
SwapFirstAndLastLines(matr);
Console.WriteLine();
PrintMatrix(matr);