using System;
using MathLibrary;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введите значение x, используя '.' (от -1 до 1, исключая 1): ");

        if (double.TryParse(Console.ReadLine(), out double x) && x > -1 && x < 1)
        {
            double standardResult = Math.Log(1 - x); // Результат стандартной функции
            double customResult = MathFunctions.LnOneMinusX(x); // Результат кастомной функции из DLL

            Console.WriteLine($"Результат стандартной функции: {standardResult}");
            Console.WriteLine($"Результат кастомной функции: {customResult}");
        }
        else 
        {
            Console.WriteLine("Некорректный ввод, возможно вы ввели число через ','. Значение x должно быть в диапазоне (-1, 1).");
        }
    }
}
 