// ===== Task 4: TUPLE Version =====
using System;
using System.Collections.Generic;

class TupleVersion {
    public static void Run() {
        List<(string Title, string Author, double Duration, double Price)> discs = new() {
            ("Album1", "Artist1", 3.5, 15),
            ("Album2", "Artist2", 5.0, 20),
            ("Album3", "Artist3", 3.5, 25)
        };

        int indexToRemove = discs.FindIndex(d => d.Duration == 3.5);
        if (indexToRemove != -1)
            discs.RemoveAt(indexToRemove);

        if (discs.Count >= 2) {
            discs.Insert(2, ("Album4", "Artist4", 4.5, 18));
            discs.Insert(3, ("Album5", "Artist5", 4.0, 22));
        }

        foreach (var d in discs)
            Console.WriteLine($"{d.Title} by {d.Author} - {d.Duration} min - ${d.Price}");
    }
}
