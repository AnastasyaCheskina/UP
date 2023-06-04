using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP
{
    internal class MethodMonteCarlo
    {
        static readonly Random random = new Random();
        public static void FindNumberPi() //вычислить число пи
        {
            int n = 1000, k = 0;
            double s, x, y;
            for (int i = 1; i < n; i++)
            {
                x = random.NextDouble();
                y = random.NextDouble();
                if (Math.Pow((x - 1), 2) + Math.Pow((y - 1), 2) <= 1) k += 1;
            }
            s = 4 * k / (double)n;
            Console.WriteLine("Полученный результат: " + s);
            Console.WriteLine("Фактический результат: " + Math.PI);
        }
        public static void FindSquare()
        {
            Console.WriteLine("Решения задач:");
            Console.WriteLine("Пример: " + Example());
            Console.WriteLine("Пример 1: " + Example1());
            Console.WriteLine("Пример 2: " + Example2());
            Console.WriteLine("Пример 3: " + Example3());
            Console.WriteLine("Пример 4: " + Example4());
            Console.WriteLine("Пример 5: " + Example5());
            Console.WriteLine("Пример 6: " + Example6());
        }
        private static double Example() //пример
        {
            int n = 100, k = 0;
            double s, x, y;
            double a = 8.5, b = 5; //ширина и высота
            for (int i = 1; i < n; i++)
            {
                x = a * random.NextDouble();
                y = b * random.NextDouble();
                if ((x / 3 < y) && (y < x * (10 - x) / 5)) k += 1;
            }
            s = a * b * k / (double)n;
            return s;
        }
        private static double Example1()
        {
            int n = 1000, k = 0;
            double s, x, y;
            double a = 15, b = 1; //ширина и высота
            for (int i = 1; i < n; i++)
            {
                x = a * random.NextDouble();
                y = b * random.NextDouble();
                if ((0 < y) && (y < Math.Sin(x))) k += 1;
            }
            s = a * b * k / (double)n;
            return s;
        }
        private static double Example2()
        {
            int n = 1000, k = 0;
            double s, x, y;
            double a = 7, b = 8; //ширина и высота
            for (int i = 1; i < n; i++)
            {
                x = a * random.NextDouble();
                y = b * random.NextDouble();
                if ((x / 2 < y) && (y < (x * (8 - x) / 2))) k += 1;
            }
            s = a * b * k / (double)n;
            return s;
        }
        private static double Example3()
        {
            int n = 1000, k = 0;
            double s, x, y;
            double a = 12, b = 5; //ширина и высота
            for (int i = 1; i < n; i++)
            {
                x = a * random.NextDouble();
                y = b * random.NextDouble();
                if (((Math.Pow((x - 6), 2) / 6) < y) && (y < 6)) k += 1;
            }
            s = a * b * k / (double)n;
            return s;
        }
        private static double Example4()
        {
            int n = 1000, k = 0;
            double s, x, y;
            double a = 10, b = 4; //ширина и высота
            for (int i = 1; i < n; i++)
            {
                x = a * random.NextDouble();
                y = b * random.NextDouble();
                if ((x / 5 < y) && (y < x * (12 - x) / 9)) k += 1;
            }
            s = a * b * k / (double)n;
            return s;
        }
        private static double Example5()
        {
            int n = 1000, k = 0;
            double s, x, y;
            double a = 8, b = 4; //ширина и высота
            for (int i = 1; i < n; i++)
            {
                x = a * random.NextDouble();
                y = b * random.NextDouble();
                if (((8 - x) / 8 < y) && (y < x * (8 - x) / 4)) k += 1;
            }
            s = a * b * k / (double)n;
            return s;
        }
        private static double Example6()
        {
            int n = 1000, k = 0;
            double s, x, y;
            double a = 3, b = 2; //ширина и высота
            for (int i = 1; i < n; i++)
            {
                x = a * random.NextDouble();
                y = b * random.NextDouble();
                if ((Math.Pow((x - 2), 2) / 2 < y) && (y < Math.Sin(x))) k += 1;
            }
            s = a * b * k / (double)n;
            return s;
        }
    }
}
