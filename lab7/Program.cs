using System;

namespace DelegateExample
{
    // 1. Делегат
    public delegate void ProcessDelegate(Duration duration);

    // 2. Класс А с методом высшего порядка
    public class A
    {
        public void Apply(ProcessDelegate process, Duration duration)
        {
            process.Invoke(duration);
        }
    }

    // 3. Вспомогательный класс Б с методами
    public class B
    {
        public void ConvertToMinutes(Duration duration)
        {
            int totalMinutes = duration.Hours * 60 + duration.Minutes;
            Console.WriteLine($"Общее время в минутах: {totalMinutes}");
        }

        public void ConvertToSeconds(Duration duration)
        {
            int totalSeconds = (duration.Hours * 3600) + (duration.Minutes * 60) + duration.Seconds;
            Console.WriteLine($"Общее время в секундах: {totalSeconds}");
        }
    }

    // 4. Класс Продолжительность
    public class Duration
    {
        public int Hours;
        public int Minutes;
        public int Seconds;

        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем объект класса Duration
            Duration duration = new Duration(2, 45, 30);

            // Создаем объект класса A
            A a = new A();

            // Создаем объект класса B
            B b = new B();

            // Создаем делегат и связываем с методами класса B
            ProcessDelegate process = b.ConvertToMinutes;
            process += b.ConvertToSeconds;

            // Применяем все методы через делегат
            a.Apply(process, duration);
        }
    }
}

