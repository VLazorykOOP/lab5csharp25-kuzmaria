// ===== Task 4: STRUCT Version =====
using System;
using System.Collections.Generic;

struct MusicDiscStruct {
    public string Title;
    public string Author;
    public double Duration;
    public double Price;

    public MusicDiscStruct(string title, string author, double duration, double price) {
        Title = title; Author = author; Duration = duration; Price = price;
    }

    public void Show() {
        Console.WriteLine($"{Title} by {Author} - {Duration} min - ${Price}");
    }
}

class StructVersion {
    public static void Run() {
        List<MusicDiscStruct> discs = new List<MusicDiscStruct> {
            new("Album1", "Artist1", 3.5, 15),
            new("Album2", "Artist2", 5.0, 20),
            new("Album3", "Artist3", 3.5, 25)
        };

        // Видалити перший з тривалістю 3.5
        int indexToRemove = discs.FindIndex(d => d.Duration == 3.5);
        if (indexToRemove != -1)
            discs.RemoveAt(indexToRemove);

        // Додати 2 після елемента з індексом 1
        if (discs.Count >= 2) {
            discs.Insert(2, new MusicDiscStruct("Album4", "Artist4", 4.5, 18));
            discs.Insert(3, new MusicDiscStruct("Album5", "Artist5", 4.0, 22));
        }

        foreach (var d in discs)
            d.Show();
    }
}
