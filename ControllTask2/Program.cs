using System;
using System.Text;

namespace ControllTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var fileProvider = new MyFileProvider(OS.Windows);
                Console.WriteLine($"Текущая ОС: Windows");
                Console.WriteLine($"Корневой путь: {fileProvider.RootDirectoryPath}");
                Console.WriteLine($"Разделитель: {fileProvider.Delimiter}");
                Console.WriteLine();

                var dir1 = fileProvider.AddDirectory("", "Documents");
                var dir2 = fileProvider.AddDirectory("Documents", "Projects");
                Console.WriteLine("Директории добавлены");
                Console.WriteLine();

                fileProvider.GetNextDirectory("Documents");
                fileProvider.GetNextDirectory("Projects");
                Console.WriteLine($"Текущая директория: {fileProvider.CurrentPath}");
                Console.WriteLine();

                var file = new File("report", "txt");
                file.Data = Encoding.UTF8.GetBytes("Hello, World!");
                fileProvider.SaveFileOnCurrentDirectory(file);
                Console.WriteLine($"Файл сохранен: {file}");
                Console.WriteLine();

                var foundFile = fileProvider.FindFileByPath("Documents\\Projects\\report.txt");
                Console.WriteLine($"Найден файл: {foundFile?.Name}.{foundFile?.Extension}");
                Console.WriteLine();

                fileProvider.ChangeOS(OS.Unix);
                Console.WriteLine($"Текущая ОС: Unix");
                Console.WriteLine($"Корневой путь: {fileProvider.RootDirectoryPath}");
                Console.WriteLine($"Разделитель: {fileProvider.Delimiter}");
                Console.WriteLine();

                fileProvider.BackToTheRoots();
                Console.WriteLine($"Текущая директория после BackToTheRoots: {fileProvider.CurrentPath}");
                Console.WriteLine();

                var path = "home/user/documents";
                var dirNames = fileProvider.GetDirectoryNamesFromPath(path);
                Console.WriteLine($"Имена директорий из пути '{path}':");
                foreach (var dirName in dirNames)
                {
                    Console.WriteLine($"  - {dirName}");
                }

                var success = fileProvider.TryDeleteDirectory("Documents/Projects");
                Console.WriteLine($"Попытка удалить директорию: {(success ? "успешно" : "не удалось")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}