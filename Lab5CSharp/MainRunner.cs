// ===== Main Runner =====
using System;

public class Program {
    public static void Main(string[] args) {
        Console.WriteLine("===== Task 1: Engine Hierarchy =====");
        Engine e = new Engine("BasicEngine");
        InternalCombustionEngine ice = new InternalCombustionEngine("ICE-Model", 6);
        DieselEngine de = new DieselEngine("DieselX", 8, 400);
        JetEngine je = new JetEngine("JetX", 2000);
        e.Show(); ice.Show(); de.Show(); je.Show();

        Console.WriteLine("\n===== Task 3: Function Hierarchy =====");
        Function[] functions = new Function[] {
            new Line(2, 3),
            new Quadratic(1, -2, 1),
            new Hyperbola(10)
        };
        double x = 2.0;
        foreach (var func in functions)
            func.Show(x);

        Console.WriteLine("\n===== Task 4: STRUCT Version =====");
        StructVersion.Run();

        Console.WriteLine("\n===== Task 4: TUPLE Version =====");
        TupleVersion.Run();

        Console.WriteLine("\n===== Task 4: RECORD Version =====");
        RecordVersion.Run();
    }
}
