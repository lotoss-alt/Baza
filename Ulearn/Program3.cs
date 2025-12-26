namespace Ulearn;

class Program3
{
    //Expr3. Задано время Н часов (ровно). Вычислить угол в градусах между часовой и минутной стрелками.
    //Например, 5 часов -> 150 градусов, 20 часов -> 120 градусов. Не использовать циклы.
    static void Main(string[] args)
    {
        Console.WriteLine("Запишите количество часов(0-23): ");
        int hours = Convert.ToInt32(Console.ReadLine());

        int hourtime = hours % 12;

        double angle = Math.Abs(hourtime * 30);

        if (angle > 180)
        {
            angle = 360 - angle;
        }
        Console.WriteLine($"Время: {hours} часов");
        Console.WriteLine($"Угол между стрелками: {angle}°");
    }
}