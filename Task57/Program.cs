// Задача 57: 
// Составить частотный словарь элементов двумерного массива. 
// Частотный словарь содержит информацию о том, сколько раз встречается элемент во
// входных данных.

int GeneratorRandomInt(int minValue, int maxValue)  // генератор Random int в диапазоне [min,max]
{
    Random rnd = new Random();
    return rnd.Next(minValue, maxValue + 1);
}

int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)  // создает массив
{
    int[,] matrix = new int[rows, columns];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = GeneratorRandomInt(min, max);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)     // вывод массива в консоль
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        // Console.Write("[");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j]} ");
            else Console.Write($"{matrix[i, j]}");
        }
        // Console.WriteLine("]");
        Console.WriteLine();
    }
}

int[] ConvertArray2DToSortedArray(int[,] matrix)    // преобразует 2D массив в одномерный отсортированный массив
{
    int[] array = new int[matrix.GetLength(0) * matrix.GetLength(1)];
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int k = 0;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
           array[k] = matrix[i, j];
           k++;
        }
    }
    Array.Sort(array);
    return array;
}

void PrintArray(int[] array)    // печать одномерного массива
{
    Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        if (i < array.Length - 1) Console.Write($"{array[i]}, ");
        else Console.Write($"{array[i]}");
    }
    Console.Write("]");
}

void MatchedNumberCount(int[] array)
{
    int temp = array[0];
    int count = 1;
    for (int i = 1; i < array.Length; i++)
    {
        if (temp == array[i]) count++;
        else
        {
            Console.WriteLine($"{temp} встречается {count} раз.");
            temp = array[i];
            count = 1;
        }
    }
    Console.WriteLine($"{temp} встречается {count} раз.");
}


Console.Clear();
int matrixSizeMin = 3;
int matrixSizeMax = 5;
int matrixElemMin = 1;
int matrixElemMax = 9;
int matrixRow = GeneratorRandomInt(matrixSizeMin, matrixSizeMax);
int matrixCol = GeneratorRandomInt(matrixSizeMin, matrixSizeMax);
int[,] array2D = CreateMatrixRndInt(matrixRow, matrixCol, matrixElemMin, matrixElemMax);

PrintMatrix(array2D);
Console.WriteLine();

int[] arr = ConvertArray2DToSortedArray(array2D);
PrintArray(arr);
Console.WriteLine();

MatchedNumberCount(arr);
