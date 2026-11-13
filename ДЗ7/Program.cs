using System;

class Program
{
    static void Main(string[] args)
    {
        int number = 42;
        double d = 3.14;
        DateTime date = DateTime.Now;
        string str = "hello";
        object obj = 123;
        object nullObj = null;
        Person person = new Person();

        CheckFormattable(number);
        CheckFormattable(d);
        CheckFormattable(date);
        CheckFormattable(str);
        CheckFormattable(obj);
        CheckFormattable(nullObj);
        CheckFormattable(person);

        Console.ReadKey();
    }

    static void CheckFormattable(object obj)
    {
        if (obj is IFormattable)
        {
            IFormattable formattable = obj as IFormattable;
            string formatted = formattable.ToString("G", null);
            Console.WriteLine($"'{obj}' ({obj.GetType().Name}) реализует IFormattable. Формат 'G': {formatted}");
        }
        else
        {
            string typeName = obj == null ? "null" : obj.GetType().Name;
            Console.WriteLine($"Объект ({typeName}) НЕ реализует IFormattable.");
        }
    }
}

class Person
{
    public string Name { get; set; } = "Иван";
}