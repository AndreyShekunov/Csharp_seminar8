// Задача 56: Задайте прямоугольный двумерный массив.
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке
// и выдаёт номер строки с наименьшей суммой элементов: 1 строка

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


// метод cуммирования элементов строк и запись сумм в отдельный одномерный массив
int[] SumLineMatrix(int[,] matrix)
{
    int[] sumArray = new int[matrix.GetLength(0)];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        sumArray[i] = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sumArray[i] += matrix[i, j];
        }
    }
    return sumArray;
}

// метод поиска индекса строки с минимальной суммой элементов
int FindIndexLineMinSum(int[] array)
{
    int minRowInd = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] < array[minRowInd])
        {
            minRowInd = i;
        }
    }
    return minRowInd;
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
int[] sumArr = SumLineMatrix(matr);
Console.WriteLine("Суммы по строкам равны:");
Console.WriteLine(string.Join(", ", sumArr));
int minLineIndex = FindIndexLineMinSum(sumArr);
Console.WriteLine($"Индекс строки с минимальной суммой = {minLineIndex}");