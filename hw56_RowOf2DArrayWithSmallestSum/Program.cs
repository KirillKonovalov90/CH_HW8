//Программа принимает 2хмерный массив и находит строку 
//с наименьшей суммой элементов

int[,] CreateArray(int rows, int columns, int minValue = 0, int maxValue = 100)
{
    int[,] array = new int[rows, columns];

    var rnd = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(minValue, maxValue + 1);
        }
    }

    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j],3} ");
        }
        Console.WriteLine();
    }
}

int[] RowWithLeastSummOfElements(int[,] array)
{
    int minSumm = 0, minIndex = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        int summ = 0;

        for (int j = 0; j < array.GetLength(1); j++)
        {
            summ += array[i, j];
        }

        if (i == 0)
        {
            minSumm = summ;
        }

        else if (summ < minSumm)
        {
            minSumm = summ;
            minIndex = i;
        }
    }
    int[] result = { minSumm, minIndex + 1 };
    return result;
}

int[] massiveSize, resultMassive;
int[,] massive;

Console.Write("Введите количество строк и столбцов массива через пробел: ");
massiveSize = Console.ReadLine()!.Split(" ").Select(int.Parse).ToArray();

massive = CreateArray(massiveSize[0], massiveSize[1], -10, 10);

PrintArray(massive);
Console.WriteLine();

resultMassive = RowWithLeastSummOfElements(massive);

Console.WriteLine($"Строка {resultMassive[1]} содержит минимальную сумму элементов = {resultMassive[0]}");