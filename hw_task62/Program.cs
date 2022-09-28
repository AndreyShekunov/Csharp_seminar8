// Задача 62. Заполните спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 1 2 3 4
// 12 13 14 5
// 11 16 15 6
// 10 9 8 7

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

// метод преобразования массива в спираль
int[,] SpiralArray(int[] array)
{
    int n = 4;
    int[,] matrix = new int[n, n];
    int m = n / 2,

    Length = n,
    count = 0;

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < Length; j++) // Заполнение слева направо
        {
            matrix[i, i + j] = array[count++];
        }
        for (int j = 1; j < Length; j++)// Заполнение сверху вниз
        {
            matrix[i + j, n - i - 1] = array[count++];
        }

        Length -= 2;

        for (int j = Length; j >= 0; j--) // Заполнение справа налево
        {
            matrix[n - i - 1, i + j] = array[count++];
        }
        for (int j = Length; j >= 1; j--)// Заполнение снизу вверх
        {
            matrix[i + j, i] = array[count++];
        }
    }
    return matrix;
}

int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
int[,] matrix = SpiralArray(array);
Console.WriteLine();
Console.WriteLine("Спиральная матрица: ");
Console.WriteLine();
PrintMatrix(matrix);
Console.WriteLine();