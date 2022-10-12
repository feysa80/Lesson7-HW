// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
// Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
// и возвращает значение этого элемента или же указание, что такого элемента нет.
//Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
// Дополнительная задача (задача со звёздочкой): Задайте двумерный массив из целых чисел. Определите, есть столбец в массиве, 
// сумма которого, больше суммы элементов расположенных в четырех "углах" двумерного массива.

using System.Diagnostics.Metrics;
using System.Reflection.Metadata;

Console.Clear();
Console.WriteLine("Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.");
Console.WriteLine("Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.");
Console.WriteLine("Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.");
Console.WriteLine("Дополнительная задача 1.(задача со звёздочкой): Задайте двумерный массив из целых чисел. Определите, есть столбец в массиве, сумма которого, больше суммы элементов расположенных в четырех \"углах\" двумерного массива.");
Console.Write("Введите номер задачи: ");
int task = Convert.ToInt32(Console.ReadLine());

switch (task){
    case 47: 
        Console.Clear();
        Console.WriteLine("Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.");
        FillFloat();
        break;
    case 50: 
        Console.Clear();
        Console.WriteLine("Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.");
        int [,] array50 = Begin(0,10);
        PrintArray(array50);
        FindElement(array50);
        break;
    case 52:
        Console.Clear();
        Console.WriteLine("Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.");
        int [,] array52 = Begin(0,10);
        PrintArray(array52);
        double [] result52 = FindAM(array52);
        Console.WriteLine("Средние арифметические значения: " + String.Join("; ",result52));
        break;
    case 1:
        Console.Clear();
        Console.WriteLine("Дополнительная задача 1.(задача со звёздочкой): Задайте двумерный массив из целых чисел. Определите, есть столбец в массиве, сумма которого, больше суммы элементов расположенных в четырех \"углах\" двумерного массива.");
        int[,] array1 = Begin(0,10);
        PrintArray(array1);
        Task1(array1);
        break;
    default: Console.WriteLine("Неправильный ввод");
        break;
}

void FillFloat(){
    Console.Write("Введите количество строк в массиве: ");
    int row = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите количество колонок в массиве: ");
    int column = Convert.ToInt32(Console.ReadLine());
    double[,] array = new double[row, column];
    for(int i=0; i < row; i++){
        for(int j=0; j < column; j++){
            int temp = new Random().Next(-100,100);
            array[i,j] = Convert.ToDouble(temp)/10;
            Console.Write(array[i,j] + "\t");
        }
        Console.WriteLine();
    }
}
int[,] Begin(int min, int max){
    Console.Write("Введите количество строк в массиве: ");
    int row = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите количество колонок в массиве: ");
    int column = Convert.ToInt32(Console.ReadLine());
    int[,] array = new int[row,column];
    for(int i=0; i < row; i++){
        for(int j=0; j < column; j++){
            array[i,j] = new Random().Next(min, max);
        }
    }
    return array;
}
void FindElement(int[,] someArray){
    int row = someArray.GetLength(0);
    int column = someArray.GetLength(1);
    Console.Write("Введите индекс строки: ");
    int rowNumber = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите индекс колонки: ");
    int columnNumber = Convert.ToInt32(Console.ReadLine());
    if(rowNumber >= row || columnNumber >= column) Console.WriteLine("Такого элемента нет");
    else Console.WriteLine(someArray[rowNumber,columnNumber]);
}
void PrintArray(int[,] someArray){
    int row = someArray.GetLength(0);
    int column = someArray.GetLength(1);
    for(int i = 0; i < row; i++){
        for(int j=0; j < column; j++){
            Console.Write(someArray[i,j] + "\t");
        }
        Console.WriteLine();
    }
}
double[] FindAM(int[,] someArray){
    int row = someArray.GetLength(0);
    int column = someArray.GetLength(1);
    double[] result = new double[column];
    int sum = 0;
    for(int i = 0; i < column; i++){
        for(int j =0; j < row; j++){
            sum = sum + someArray[j,i];
        }
        result[i] = Math.Round(Convert.ToDouble(sum)/Convert.ToDouble(row),1);
        sum = 0;
    }
    return result;
}
void Task1(int[,] someArray){
    int row = someArray.GetLength(0);
    int column = someArray.GetLength(1);
    int sum = someArray[0,0] + someArray[0, column -1] + someArray[row -1, 0] + someArray[row -1, column -1];
    int sumColumn = 0;
    int count = 0;
    List<int> columnMax = new List<int>();
    List<int> columnSum = new List<int>();
    for(int i = 0; i < column; i++){
        for(int j = 0; j < row; j++){
            sumColumn = sumColumn + someArray[j,i];
        }
        if (sumColumn > sum) {
            columnMax.Add(i); 
            columnSum.Add(sumColumn);
            count=count+1;}
        sumColumn = 0;
    }
    Console.WriteLine($"Сумма угловых значений массива - {sum}");
    if(count > 0) {
        Console.WriteLine($"Столбцов, удобвлетворяющих устовию - {count}");
        for(int i = 0; i < count; i++){
            Console.WriteLine($"В столбце с индексом {i} сумма значений равна {columnSum[i]}");
        }

    }
    else Console.WriteLine("Столбцов, удовлетворяющих условию, нет");
}