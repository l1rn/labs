using System;

namespace MathLibrary
{
    public class MathFunctions
    {
        public static double LnOneMinusX(double x)
        {
            double tolerance = 1e-9; // Точность
            double term = x;         // Первый член ряда
            double sum = -x;         // Начальное значение суммы
            int n = 2;               // Индекс для рекурсии

            while (Math.Abs(term) > tolerance)
            {
                term = Math.Pow(x, n) / n;
                sum -= term; // Добавляем следующий член ряда
                n++;
            }

            return sum;
        }
    }
}
