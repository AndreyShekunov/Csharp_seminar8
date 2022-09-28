// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// массив размером 2 x 2 x 2
// 12(0,0,0) 22(0,0,1)
// 45(1,0,0) 53(1,0,1)

int ReadNumber(string message) // метод ввода числа
{
    Console.WriteLine(message);
    return Convert.ToInt32(Console.ReadLine());
}
// метод создания трёхмерного массив из неповторяющихся двузначных чисел
int[,,] GetCube(int rowsCount, int columnsCount, int tableCount, int leftRange = 10, int rightRange = 98) // 1 и 10 значения по умолчанию
{
    int[,,] cube = new int[rowsCount, columnsCount, tableCount];

    for (int i = 0; i < cube.GetLength(0); i++)
    {
        for (int j = 0; j < cube.GetLength(1); j++)
        {
            int k = 0;
            while (k < cube.GetLength(2))
            {
                int rand = new Random().Next(leftRange, rightRange + 1);
                if (FindElementInCube(cube, rand)) continue; // вызов метода поиска созданного числа в текущем кубе
                cube[i, j, k] = rand;
                k++;
            }

        }
    }
    return cube;
}
// метод поиска элемента в трехмерном массиве
bool FindElementInCube(int[,,] cube, int rand)
{
    for (int i = 0; i < cube.GetLength(0); i++)
    {
        for (int j = 0; j < cube.GetLength(1); j++)
        {
            for (int k = 0; k < cube.GetLength(2); k++)
            {
                if (cube[i, j, k] == rand) return true; // если число найдена то передаем Истина
            }
        }
    }
    return false; // если число не найдено, то перадем Ложь
}

    void PrintCube(int[,,] cube)
    {
        for (int i = 0; i < cube.GetLength(0); i++)
        {
            for (int j = 0; j < cube.GetLength(1); j++)
            {
                for (int k = 0; k < cube.GetLength(2); k++)
                {
                    Console.Write($"{cube[i, j, k]} ({i}, {j}, {k}) ");
                }

            }
            Console.WriteLine();
        }
    }

    Console.WriteLine("Введите данный для создания трёхмерного массива:");
    int m = ReadNumber("Введите количество строк");
    int n = ReadNumber("Введите количество столбцов");
    int z = ReadNumber("Введите количество таблиц");
    int[,,] cube = GetCube(m, n, z);
    PrintCube(cube);


