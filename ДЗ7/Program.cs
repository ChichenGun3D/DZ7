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
            Console.WriteLine($"Файл '{inputFile}' не найден.");
            Console.ReadKey();
            return;
        }

        Console.Write("Введите имя выходного файла: ");
        string outputFile = Console.ReadLine();

        try
        {
            string[] lines = File.ReadAllLines(inputFile);
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                foreach (string line in lines)
                {
                    string s = line;
                    SearchMail(ref s);
                    if (!string.IsNullOrEmpty(s))
                        writer.WriteLine(s);
                }
            }
            Console.WriteLine($"Готово! Адреса записаны в '{outputFile}'.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.ReadKey();
    }

    public static void SearchMail(ref string s)
    {
        if (string.IsNullOrEmpty(s))
            return;

        int index = s.IndexOf('#');
        if (index >= 0)
            s = s.Substring(index + 1).Trim();
        else
            s = string.Empty;
    }
}