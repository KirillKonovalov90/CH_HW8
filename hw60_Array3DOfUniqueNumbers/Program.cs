//Программа формирует 3х мерный массив из неповторяющихся чисел

void Print1DArray(int[] array)
{
    Console.WriteLine("[" + string.Join(", ", array) + "]");
}

int[] CreateArrayOfTheRealNumbers(int minValue, int maxValue)
{
    int[] array = new int[2 * (maxValue - minValue) + 2];

    for (int i = 0; i < array.Length / 2; i++)
    {
        array[i] = -(minValue + i);
    }

    for (int i = array.Length / 2; i < array.Length; i++)
    {
        array[i] = minValue + i - (maxValue - minValue) - 1;
    }

    return array;
}

void ShuffleArray(int[] array)
{
    int temp, randomIndex;
    var rnd = new Random();

    for (int i = 0; i < array.Length / 2; i++)
    {
        temp = array[i];
        randomIndex = rnd.Next(array.Length / 2, array.Length);
        array[i] = array[randomIndex];
        array[randomIndex] = temp;
    }
}

int[,,] Fill3DArray(int rows, int columns, int depth, int[] fillData)
{
    int[,,] array = new int[rows, columns, depth];

    if (rows * columns * depth > fillData.Length)
    {
        Console.WriteLine("Задайте больший массив вводных данных, либо меньшие размеры 3хмерного массива");
        Console.WriteLine();
        return null;    // Не догадался как лучше вернуть ошибку и обработать её в данном случае
    }

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                array[i, j, k] = fillData[(k + j * array.GetLength(2) + i * array.GetLength(2) * array.GetLength(1))];
            }
        }
    }

    return array;
}

void Print3DArrayRows(int[,,] array)
{
    if (array == null)
    {
        return;
    }
    
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write($"{array[i, j, k],3}({i}, {j}, {k})  ");
            }

            Console.WriteLine();
        }
    }
}


int[] size, data = CreateArrayOfTheRealNumbers(10, 99);
int[,,] massive3D;

Console.Write("Введите желаемые размеры 3хмерного массива через пробел: ");
size = Console.ReadLine()!.Split(" ").Select(int.Parse).ToArray();

Print1DArray(data);
Console.WriteLine();

ShuffleArray(data);

Print1DArray(data);
Console.WriteLine();

massive3D = Fill3DArray(size[0], size[1], size[2], data);

Print3DArrayRows(massive3D);