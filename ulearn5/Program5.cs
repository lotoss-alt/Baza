namespace Ulearn;

class Program5
{
//Expr5. Найти количество високосных лет на отрезке [a, b] не используя циклы.
    static void Main()
    {
        // Ввод данных
        Console.WriteLine("Введите диапазон лет [a, b]: ");
        Console.Write("a = ");
        int startYear = int.Parse(Console.ReadLine());
        
        Console.Write("b = ");
        int endYear = int.Parse(Console.ReadLine());
        
        if (startYear > endYear)
        {
            (startYear, endYear) = (endYear, startYear);
        }
        

        int divisibleBy4 = endYear / 4 - (startYear - 1) / 4;
        

        int divisibleBy100 = endYear / 100 - (startYear - 1) / 100;
        

        int divisibleBy400 = endYear / 400 - (startYear - 1) / 400;
        
        int leapYearsCount = divisibleBy4 - divisibleBy100 + divisibleBy400;
        
        Console.WriteLine($"\nДиапазон: от {startYear} до {endYear} года");
        Console.WriteLine($"Лет, кратных 4: {divisibleBy4}");
        Console.WriteLine($"Лет, кратных 100 (вычитаем): {divisibleBy100}");
        Console.WriteLine($"Лет, кратных 400 (прибавляем): {divisibleBy400}");
        Console.WriteLine($"\nИТОГО високосных лет: {leapYearsCount}");
    }
}