using System;
using System.Collections.Generic;

// Базовый класс для всех сотрудников
class Employee
{
    public string Name { get; set; }
    public Employee Boss { get; set; } // Прямой руководитель

    public Employee(string name, Employee boss = null)
    {
        Name = name;
        Boss = boss;
    }

    // Метод для получения задачи
    public void TakeTask(string taskName, Employee giver)
    {
        // Проверяем, является ли giver прямым руководителем (Boss)
        if (this.Boss == giver)
        {
            Console.WriteLine($"Сотрудник {this.Name} БЕРЕТ задачу: «{taskName}» (от {giver.Name}).");
        }
        else
        {
            Console.WriteLine($"Сотрудник {this.Name} ОТКАЗЫВАЕТСЯ брать задачу: «{taskName}» (от {giver.Name}). Причина: не прямое руководство.");
        }
    }
}

class Program
{
    // Категории для распределения задач
    enum TaskType { Management, IT_Systems, IT_Developers }

    static void Main(string[] args)
    {
        // 1. Строим иерархию (снизу вверх или сверху вниз)

        // Генеральный директор
        Employee timur = new Employee("Тимур (Ген. директор)");

        // Подчиненные Тимура
        Employee rashid = new Employee("Рашид (Фин. директор)", timur);
        Employee ilham = new Employee("О Ильхам (Директор по автоматизации)", timur);

        // Бухгалтерия
        Employee lukas = new Employee("Лукас (Гл. бухгалтер)", rashid);

        // ИТ отдел (Начальство)
        Employee orkady = new Employee("Оркадий (Начальник инф. систем)", ilham);
        Employee volodya = new Employee("Володя (Зам. начальника)", ilham);

        // Сектор системщиков
        Employee ilshat = new Employee("Ильшат (Гл. системщик)", orkady); // Слушается Оркадия
        Employee ivanych = new Employee("Иваныч (Зам. гл. системщика)", ilshat);
        Employee ilya = new Employee("Илья (Системщик)", ivanych);
        Employee vitya = new Employee("Витя (Системщик)", ivanych);
        Employee zhenya = new Employee("Женя (Системщик)", ivanych);

        // Сектор разработчиков
        Employee sergey = new Employee("Сергей (Гл. разработчик)", orkady); // Слушается Оркадия
        Employee lyaysan = new Employee("Ляйсан (Зам. гл. разработчика)", sergey);
        Employee marat = new Employee("Марат (Разработчик)", lyaysan);
        Employee dina = new Employee("Дина (Разработчик)", lyaysan);
        Employee ildar = new Employee("Ильдар (Разработчик)", lyaysan);
        Employee anton = new Employee("Антон (Разработчик)", lyaysan);

        // 2. Создаем примитивные задачи
        // Формат: Название задачи, Кому (Категория), От кого
        var tasks = new List<Tuple<string, TaskType, Employee>>()
        {
            Tuple.Create("Настроить локальную сеть", TaskType.IT_Systems, orkady),
            Tuple.Create("Разработать модуль 1С", TaskType.IT_Developers, volodya),
            Tuple.Create("Автоматизация бухгалтерии", TaskType.IT_Developers, ilham),
            Tuple.Create("Сдать отчет за квартал", TaskType.Management, rashid)
        };

        // 3. Распределяем задачи
        Console.WriteLine("=== РАСПРЕДЕЛЕНИЕ ЗАДАЧ ===\n");

        foreach (var task in tasks)
        {
            string taskName = task.Item1;
            TaskType type = task.Item2;
            Employee giver = task.Item3;

            Console.WriteLine($"От {giver.Name} даётся задача «{taskName}»...");

            if (type == TaskType.Management)
            {
                // Задачи для начальства (например, Лукасу от Рашида)
                lukas.TakeTask(taskName, giver);
            }
            else if (type == TaskType.IT_Systems)
            {
                // Даем задачу первому попавшемуся системщику (например, Илье)
                ilya.TakeTask(taskName, giver);
            }
            else if (type == TaskType.IT_Developers)
            {
                // Даем задачу первому попавшемуся разработчику (например, Дине)
                dina.TakeTask(taskName, giver);
            }
            Console.WriteLine();
        }

        // Демонстрация нарушения субординации
        Console.WriteLine("--- Проверка субординации ---");
        Console.WriteLine("Попытка передать задачу через голову (Марат дает задачу Дине):");
        dina.TakeTask("Помыть кофеварку", marat);

        Console.ReadKey();
    }
}