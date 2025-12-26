using System;

namespace Ulearn;

class Program
{
    //Expr7. Найти вектор, параллельный прямой. Перпендикулярный прямой. Прямая задана коэффициентами уравнения прямой.
    static void Main()
    {
        Console.WriteLine("=== Векторы, параллельный и перпендикулярный прямой ===\n");
            
        Console.WriteLine("Введите коэффициенты уравнения прямой Ax + By + C = 0:");
            
        Console.Write("A = ");
        double A = GetDoubleInput();
            
        Console.Write("B = ");
        double B = GetDoubleInput();
            
        Console.Write("C = ");
        double C = GetDoubleInput();
            
        if (A == 0 && B == 0)
        {
            Console.WriteLine("Ошибка: A и B не могут быть одновременно равны нулю!");
            return;
        }
            
        (double px, double py) = GetParallelVector(A, B);
        (double nx, double ny) = GetPerpendicularVector(A, B);
            
        Console.WriteLine("\n=== Результаты ===");
        Console.WriteLine($"Уравнение прямой: {A:F2}x + {B:F2}y + {C:F2} = 0");
        Console.WriteLine($"Вектор, параллельный прямой: ({px:F2}, {py:F2})");
        Console.WriteLine($"Вектор, перпендикулярный прямой: ({nx:F2}, {ny:F2})");
            
        Console.WriteLine("\n=== Примеры ===");
        Console.WriteLine("Для прямой 2x + 3y + 5 = 0:");
        Console.WriteLine("  Параллельный вектор: (-3, 2) или (3, -2)");
        Console.WriteLine("  Перпендикулярный вектор: (2, 3) или (-2, -3)");
    }
        
    static (double x, double y) GetParallelVector(double A, double B)
    {
        return (-B, A);
    }
        
    static (double x, double y) GetPerpendicularVector(double A, double B)
    {
        return (A, B);
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