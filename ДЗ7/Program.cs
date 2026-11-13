using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите имя исходного файла: ");
        string inputFile = Console.ReadLine();

        if (!File.Exists(inputFile))
        {
            Console.WriteLine($"Файл '{inputFile}' не найден. Программа завершает работу.");
            Console.ReadKey();
            return;
        }

        Console.Write("Введите имя выходного файла: ");
        string outputFile = Console.ReadLine();

        try
        {
            string content = File.ReadAllText(inputFile);
            File.WriteAllText(outputFile, content.ToUpper());
            Console.WriteLine($"Готово! Содержимое записано в '{outputFile}' заглавными буквами.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка при работе с файлом: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Нет доступа к файлу: {ex.Message}");
        }

        Console.ReadKey();
    }
}
