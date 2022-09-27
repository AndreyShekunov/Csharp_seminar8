// Задача 59: Задайте двумерный массив из целых чисел.
// Напишите программу, которая удалит строку и столбец, 
// на пересечении которых расположен наименьший элемент массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Наименьший элемент - 1, на выходе получим
// следующий массив:
// 9 4 2
// 2 2 6
// 3 4 7

int ReadNumber(string message) // метод ввода числа
{
    Console.WriteLine(message);
    return Convert.ToInt32(Console.ReadLine());
}

// метод создания двумерного массив (матрицы) 
int[,] GetMatrix(int rowsCount, int columnsCount, int leftRange = 0, int rightRange = 9) // - 10 и 10 значения по умолчанию
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


// метод поиска минимального элемента и записи нового массива без учета строки и столбца где находится мин элемент
int[,] DeleteIntersectionByMinElement(int[,] matrix)
{
    int[,] newMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];

    int minElement = matrix[0, 0]; // минимум ровно 1 элементу массива
    int minRow = 0; // индекс строки с минимальным элементом
    int minColumn = 0; // индекс столбца с минимальным элементом

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] < minElement) // если элемент массива меньше минимума
            {
                minElement = matrix[i, j]; // то переназначаем минимальный элемент
                minRow = i; // сохраняем индекс строки минимального элемента
                minColumn = j; // сохраняем индекс столбца минимального элемента
            }
        }
    }
    int rowOffset = 0; // смещение для исходной матрицы по строке
    int columnOffset = 0; // смещение для исходной матрицы по столбцу

    // заполняем новый массив
    for (int i = 0; i < newMatrix.GetLength(0); i++)
    {
        if (i == minRow) // если строка где у нас минимальное значение
        {
            rowOffset++; // тогда смещаемся на 1
        }
        for (int j = 0; j < newMatrix.GetLength(1); j++)
        {
            if (j == minColumn) // если столбец где у нас минимальное значение
            {
                columnOffset++; // тогда смещаемся на 1
            }
            newMatrix[i,j] = matrix[i + rowOffset, j + columnOffset]; //записать в новую матрицу данные из старой с учетом всех смещений
        }
        columnOffset = 0; //обнулить смещение по столбцу
    }
    return newMatrix;
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
int[,] matrNew = DeleteIntersectionByMinElement(matr);
Console.WriteLine();
PrintMatrix(matrNew);
