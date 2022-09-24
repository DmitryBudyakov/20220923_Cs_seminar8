// Задача 59: 
// Задайте двумерный массив из целых чисел.
// Напишите программу, которая удалит строку и столбец, на
// пересечении которых расположен наименьший элемент
// массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Наименьший элемент - 1, на выходе получим
// следующий массив:
// 9 2 3
// 4 2 4
// 2 6 7

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

void PrintMatrix(int[,] matrix)     // вывод 2D массива в консоль
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

int[] SearchMinInArray2D(int[,] matrix) // находит Id min элемента в 2D массиве
{
    int rowMinId = 0;
    int columnMinId = 0;
    int minValue = matrix[rowMinId, columnMinId];
    int[] minValueIdArray = new int[3];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] < minValue)
            {
                minValue = matrix[i, j];
                rowMinId = i;
                columnMinId = j;
            }
        }
    }
    minValueIdArray[0] = rowMinId;
    minValueIdArray[1] = columnMinId;
    minValueIdArray[2] = minValue;
    // Console.WriteLine($"min: {minValue} row: {rowMinId} col: {columnMinId}");   // проверка

    return minValueIdArray;
}

int[,] DeleteRowColumnFromArray2D(int[,] matrix, int deleteRow, int deleteColumn)   // 2D массив после удаления из исходного строки и столбца 
{
    int newArrRows = matrix.GetLength(0) - 1;
    int newArrColumns = matrix.GetLength(1) - 1;

    int[,] newArray = new int[newArrRows, newArrColumns];
    int k = 0;
    int l = 0;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (i != deleteRow)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j != deleteColumn)
                {
                    newArray[k, l] = matrix[i, j];
                    // Console.WriteLine($"i:{i} j:{j} value:{matrix[i, j]} | k:{k} l:{l} value: {newArray[k, l]}");   // для проверки
                    // Console.WriteLine($"i:{i} j:{j} value:{matrix[i, j]}");  // провекрка для void
                    // Console.Write($"{matrix[i, j]} ");  // если void
                    if (l != newArrColumns - 1) l++;
                    else l = 0;
                }
            }
            // Console.WriteLine();    // если void
            k++;
        }

    }
    return newArray;
}

void PrintArray(int[] array)    // печать в консоль 1D массива
{
    Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        if (i < array.Length - 1) Console.Write($"{array[i]}, ");
        else Console.Write($"{array[i]}");
    }
    Console.WriteLine("]");
}



Console.Clear();
int matrixSizeMin = 3;
int matrixSizeMax = 5;
int matrixElemMin = 0;
int matrixElemMax = 9;
int matrixRow = GeneratorRandomInt(matrixSizeMin, matrixSizeMax);
int matrixCol = GeneratorRandomInt(matrixSizeMin, matrixSizeMax);
int[,] array2D = CreateMatrixRndInt(matrixRow, matrixCol, matrixElemMin, matrixElemMax);

// тестовый массив
// int[,] array2D = {
//     {1,3,2},
//     {5,7,5},
//     {6,0,8}
//     };

Console.WriteLine("Исходный массив:");
PrintMatrix(array2D);
Console.WriteLine();

int[] minValueIdArr = SearchMinInArray2D(array2D);
// PrintArray(minValueIdArr);
// Console.WriteLine();
Console.WriteLine($"Наименьший элемент: {minValueIdArr[2]}, row: {minValueIdArr[0]} column: {minValueIdArr[1]}");
Console.WriteLine();

int[,] newArr = DeleteRowColumnFromArray2D(array2D, minValueIdArr[0], minValueIdArr[1]);
// DeleteRowColumnFromArray2D(array2D, minValueIdArr[0], minValueIdArr[1]);

Console.WriteLine("Новый массив:");
PrintMatrix(newArr);
Console.WriteLine();
