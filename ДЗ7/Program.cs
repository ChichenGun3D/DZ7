using System;
using System.Collections.Generic;

class Song
{
    string name;
    string author;
    Song prev;

    public void SetName(string name)
    {
        this.name = name;
    }

    public void SetAuthor(string author)
    {
        this.author = author;
    }

    public void SetPrev(Song prev)
    {
        this.prev = prev;
    }

    public void Print()
    {
        Console.WriteLine("Песня: " + name + ", исполнитель: " + author);
    }

    public string Title()
    {
        return name + " - " + author;
    }

    public override bool Equals(object d)
    {
        Song other = d as Song;
        if (other == null)
            return false;
        return this.name == other.name && this.author == other.author;
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Song> songs = new List<Song>();

        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"--- Ввод песни №{i + 1} ---");

            Song song = new Song();

            Console.Write("Введите название песни: ");
            song.SetName(Console.ReadLine());

            Console.Write("Введите исполнителя: ");
            song.SetAuthor(Console.ReadLine());

            if (i > 0)
            {
                song.SetPrev(songs[i - 1]);
            }

            songs.Add(song);
            Console.WriteLine();
        }

        Console.WriteLine("=== Список песен ===");
        for (int i = 0; i < songs.Count; i++)
        {
            songs[i].Print();
        }

        Console.WriteLine();

        if (songs[0].Equals(songs[1]))
            Console.WriteLine("Песня 1 и песня 2 одинаковые");
        else
            Console.WriteLine("Песня 1 и песня 2 разные");

        Console.ReadKey();
    }
}