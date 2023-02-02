//Программа принимает квадратный массив и заполняет его числами 
//спиральным методом от 1 до (2 х размер массива)

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

void SprialFilling(int[,] array)
{
    int elementSize = 0;

    if (array.GetLength(0) != array.GetLength(1))
    {
        Console.WriteLine("Программа работает корректно только для квадратного массива");
        return;
    }

    for (int k = 0; k < array.GetLength(0) - 2; k++)
    {
        for (int j = k; j < array.GetLength(1) - k; j++)
        {
            elementSize++;
            array[k, j] = elementSize;
        }
        for (int i = k + 1; i < array.GetLength(0) - k; i++)
        {
            elementSize++;
            array[i, array.GetLength(1) - 1 - k] = elementSize;
        }
        for (int j = array.GetLength(1) - 2 - k; j > k; j--)
        {
            elementSize++;
            array[array.GetLength(0) - 1 - k, j] = elementSize;
        }
        for (int i = array.GetLength(0) - 1 - k; i > k; i--)
        {
            elementSize++;
            array[i, k] = elementSize;
        }
    }
}

int[,] massive = new int[6, 6];

PrintArray(massive);
Console.WriteLine();

SprialFilling(massive);

PrintArray(massive);