using System;

namespace Ulearn
{
    class Program
    {
        //Expr8. Дана прямая L и точка A. Найти точку пересечения прямой L с перпендикулярной ей прямой P,
        //проходящей через точку A. Можете считать, что прямая задана либо двумя точками, либо коэффициентами уравнения прямой — как вам удобнее.
        static void Main()
        {
            Console.WriteLine("=== Нахождение точки пересечения с перпендикуляром ===\n");
            
            Console.WriteLine("Способ 2: Прямая L задана двумя точками\n");
            
            Console.WriteLine("Введите координаты первой точки прямой L:");
            Console.Write("x1 = ");
            double x1 = GetDoubleInput();
            Console.Write("y1 = ");
            double y1 = GetDoubleInput();
            
            Console.WriteLine("\nВведите координаты второй точки прямой L:");
            Console.Write("x2 = ");
            double x2 = GetDoubleInput();
            Console.Write("y2 = ");
            double y2 = GetDoubleInput();
            
            Console.WriteLine("\nВведите координаты точки A:");
            Console.Write("xA = ");
            double xA = GetDoubleInput();
            Console.Write("yA = ");
            double yA = GetDoubleInput();
            
            var intersection = FindIntersectionWithPerpendicular(x1, y1, x2, y2, xA, yA);
            
            Console.WriteLine("\n=== Результат ===");
            Console.WriteLine($"Прямая L проходит через точки: ({x1:F2}, {y1:F2}) и ({x2:F2}, {y2:F2})");
            Console.WriteLine($"Точка A: ({xA:F2}, {yA:F2})");
            Console.WriteLine($"Точка пересечения: ({intersection.X:F2}, {intersection.Y:F2})");
            
            double dotProduct = (x2 - x1) * (intersection.X - xA) + (y2 - y1) * (intersection.Y - yA);
            Console.WriteLine($"\nПроверка перпендикулярности (скалярное произведение): {dotProduct:E2}");
            Console.WriteLine($"Отрезки {(Math.Abs(dotProduct) < 1e-10 ? "перпендикулярны ✓" : "НЕ перпендикулярны")}");
        }
        
        static (double X, double Y) FindIntersectionWithPerpendicular(double x1, double y1, double x2, double y2, double xA, double yA)
        {
            double dx = x2 - x1;
            double dy = y2 - y1;
            
            if (Math.Abs(dx) < 1e-10 && Math.Abs(dy) < 1e-10)
            {
                throw new InvalidOperationException("Точки, задающие прямую, совпадают!");
            }
            
            double t = -(dx * (x1 - xA) + dy * (y1 - yA)) / (dx * dx + dy * dy);
            
            double xIntersect = x1 + dx * t;
            double yIntersect = y1 + dy * t;
            
            return (xIntersect, yIntersect);
        }
        
        static double GetDoubleInput()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double result))
                {
                    return result;
                }
                Console.Write("Ошибка! Введите число: ");
            }
        }
    }
}