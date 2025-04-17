// ===== Task 4: RECORD Version =====
using System;
using System.Collections.Generic;

public record MusicDiscRecord(string Title, string Author, double Duration, double Price);

class RecordVersion {
    public static void Run() {
        List<MusicDiscRecord> discs = new() {
            new("Album1", "Artist1", 3.5, 15),
            new("Album2", "Artist2", 5.0, 20),
            new("Album3", "Artist3", 3.5, 25)
        };

        int indexToRemove = discs.FindIndex(d => d.Duration == 3.5);
        if (indexToRemove != -1)
            discs.RemoveAt(indexToRemove);

        if (discs.Count >= 2) {
            discs.Insert(2, new("Album4", "Artist4", 4.5, 18));
            discs.Insert(3, new("Album5", "Artist5", 4.0, 22));
        }

        foreach (var d in discs)
            Console.WriteLine($"{d.Title} by {d.Author} - {d.Duration} min - ${d.Price}");
    }
}
