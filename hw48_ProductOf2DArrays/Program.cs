//Программа принимает 2 2хмерныx массива и выводит третий,
//являющийся их произведением

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

int[,] ProducOf2Matrixs(int[,] array1, int[,] array2)
{
    int[,] product = new int[array1.GetLength(0), array2.GetLength(1)];

    if (array1.GetLength(1) != array2.GetLength(0))
    {
        Console.WriteLine("Количество столбцов 1й матрицы должно совпадать с количеством строк 2й, иначе произведение неопределено");
    }

    for (int i = 0; i < array1.GetLength(0); i++)
    {
        for (int j = 0; j < array2.GetLength(1); j++)
        {
            for (int k = 0; k < array2.GetLength(0); k++)
            {
                product[i, j] += array1[i, k] * array2[k, j];
            }
        }
    }

    return product;

}

int[] massive1Size, massive2Size;
int[,] productOfMatrixs, matrix1, matrix2;

Console.Write("Введите количество строк и столбцов 1й матрицы через пробел: ");
massive1Size = Console.ReadLine()!.Split(" ").Select(int.Parse).ToArray();
Console.Write("Введите количество строк и столбцов 2й матрицы через пробел: ");
massive2Size = Console.ReadLine()!.Split(" ").Select(int.Parse).ToArray();

matrix1 = CreateArray(massive1Size[0], massive1Size[1], -10, 10);
matrix2 = CreateArray(massive2Size[0], massive2Size[1], -10, 10);
productOfMatrixs = ProducOf2Matrixs(matrix1, matrix2);

PrintArray(matrix1);
Console.WriteLine();
PrintArray(matrix2);
Console.WriteLine();
PrintArray(productOfMatrixs);