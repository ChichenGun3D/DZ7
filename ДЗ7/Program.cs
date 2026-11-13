using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

        string reversed = ReverseString(input);
        Console.WriteLine($"Исходная строка:  {input}");
        Console.WriteLine($"Обратная строка:  {reversed}");

        Console.ReadKey();
    }

    static string ReverseString(string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        char[] chars = str.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
}