//Программа принимает 2хмерный массив и сортирует значения в строках массива

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

void SortingRowsOf2DArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        //Использую сортировку пузырьком
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(1) - j - 1; k++)
            {
                if (array[i, k] < array[i, k + 1])
                {
                    int temp = array[i, k];
                    array[i, k] = array[i, k + 1];
                    array[i, k + 1] = temp;
                }
            }
        }
    }
}
int[] massiveSize;
int[,] massive;

Console.Write("Введите количество строк и столбцов массива через пробел: ");
massiveSize = Console.ReadLine()!.Split(" ").Select(int.Parse).ToArray();

massive = CreateArray(massiveSize[0], massiveSize[1], -10, 10);

PrintArray(massive);
Console.WriteLine();

SortingRowsOf2DArray(massive);

PrintArray(massive);