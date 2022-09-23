// Задача 53:
// Задайте двумерный массив. Напишите программу,
// которая поменяет местами первую и последнюю строку
// массива.

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

void MatrixLinesChangePlace(int[,] matrix)  // замена 1-ой и последней строки матрицы
{
    int temp = default;
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    for (int i = 0; i < columns; i++)
    {
        temp = matrix[0, i];
        matrix[0, i] = matrix[rows - 1, i];
        matrix[rows - 1, i] = temp;
    }
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

MatrixLinesChangePlace(array2D);
PrintMatrix(array2D);
