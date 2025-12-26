using System;

namespace Ulearn
{
    class Program
    {
        //Expr6. Посчитать расстояние от точки до прямой, заданной двумя разными точками.
        static void Main()
        {
            Console.WriteLine("Запишите первую точку прямой [x,y]:");
            Console.Write("x1 = ");
            double x1 = double.Parse(Console.ReadLine());
            Console.Write("y1 = ");
            double y1 = double.Parse(Console.ReadLine());
            
            Console.WriteLine("\nЗапишите вторую точку прямой [x,y]:");
            Console.Write("x2 = ");
            double x2 = double.Parse(Console.ReadLine());
            Console.Write("y2 = ");
            double y2 = double.Parse(Console.ReadLine());
            
            Console.WriteLine("\nВведите координаты точки:");
            Console.Write("x0 = ");
            double x0 = double.Parse(Console.ReadLine());
            Console.Write("y0 = ");
            double y0 = double.Parse(Console.ReadLine());
            
            double distance = CalculateDistanceToLine(x1, y1, x2, y2, x0, y0);
            
            Console.WriteLine($"\nРасстояние от точки ({x0}, {y0}) до прямой: {distance:F4}");
        }
        
        static double CalculateDistanceToLine(double x1, double y1, double x2, double y2, double x0, double y0)
        {
            
            double numerator = Math.Abs((x2 - x1) * (y1 - y0) - (x1 - x0) * (y2 - y1));
            double denominator = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            
            if (denominator == 0)
            {
                return Math.Sqrt(Math.Pow(x1 - x0, 2) + Math.Pow(y1 - y0, 2));
            }
            
            return numerator / denominator;
        }
    }
}