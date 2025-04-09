using System;
using System.Collections.Generic;

// Завдання 1-2: Ієрархія двигунів + конструктори + деструктори
class Engine
{
    public string Model;
    public int Power;

    public Engine()
    {
        Console.WriteLine("Конструктор Engine без параметрів");
    }

    public Engine(string model)
    {
        Model = model;
        Console.WriteLine("Конструктор Engine з 1 параметром");
    }

    public Engine(string model, int power)
    {
        Model = model;
        Power = power;
        Console.WriteLine("Конструктор Engine з 2 параметрами");
    }

    ~Engine()
    {
        Console.WriteLine("Деструктор Engine");
    }

    public virtual void Show()
    {
        Console.WriteLine($"Двигун: Модель = {Model}, Потужність = {Power} к.с.");
    }
}

class InternalCombustionEngine : Engine
{
    public string FuelType;

    public InternalCombustionEngine(string model, int power, string fuelType)
        : base(model, power)
    {
        FuelType = fuelType;
        Console.WriteLine("Конструктор InternalCombustionEngine");
    }

    ~InternalCombustionEngine()
    {
        Console.WriteLine("Деструктор InternalCombustionEngine");
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Тип пального: {FuelType}");
    }
}

class DieselEngine : InternalCombustionEngine
{
    public double Efficiency;

    public DieselEngine(string model, int power, string fuelType, double efficiency)
        : base(model, power, fuelType)
    {
        Efficiency = efficiency;
        Console.WriteLine("Конструктор DieselEngine");
    }

    ~DieselEngine()
    {
        Console.WriteLine("Деструктор DieselEngine");
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"ККД дизеля: {Efficiency}");
    }
}

class JetEngine : Engine
{
    public double Thrust;

    public JetEngine(string model, int power, double thrust)
        : base(model, power)
    {
        Thrust = thrust;
        Console.WriteLine("Конструктор JetEngine");
    }

    ~JetEngine()
    {
        Console.WriteLine("Деструктор JetEngine");
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Тяга: {Thrust} Н");
    }
}

// Завдання 3: Абстрактна функція + похідні
abstract class Function
{
    public abstract double Calculate(double x);
    public abstract void Show(double x);
}

class Line : Function
{
    private double a, b;

    public Line(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public override double Calculate(double x) => a * x + b;

    public override void Show(double x)
    {
        Console.WriteLine($"Лінія: y = {a}x + {b}, при x = {x}, y = {Calculate(x)}");
    }
}

class Quadratic : Function
{
    private double a, b, c;

    public Quadratic(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public override double Calculate(double x) => a * x * x + b * x + c;

    public override void Show(double x)
    {
        Console.WriteLine($"Квадратична: y = {a}x² + {b}x + {c}, при x = {x}, y = {Calculate(x)}");
    }
}

class Hyperbola : Function
{
    private double k;

    public Hyperbola(double k)
    {
        this.k = k;
    }

    public override double Calculate(double x) => k / x;

    public override void Show(double x)
    {
        Console.WriteLine($"Гіпербола: y = {k}/x, при x = {x}, y = {Calculate(x)}");
    }
}

// Завдання 4: Музичний диск (структура, кортеж, запис)
struct MusicDisc
{
    public string Name;
    public string Author;
    public int Duration;
    public double Price;

    public MusicDisc(string name, string author, int duration, double price)
    {
        Name = name;
        Author = author;
        Duration = duration;
        Price = price;
    }

    public void Show()
    {
        Console.WriteLine($"{Name} | {Author} | {Duration} хв | {Price} грн");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n--- Завдання 1-2: Ієрархія двигунів ---");
        Task1And2();

        Console.WriteLine("\n--- Завдання 3: Абстрактні функції ---");
        Task3();

        Console.WriteLine("\n--- Завдання 4: Музичний диск (структура) ---");
        Task4();
    }

    static void Task1And2()
    {
        DieselEngine diesel = new DieselEngine("Diesel-X", 150, "Дизель", 0.42);
        diesel.Show();

        JetEngine jet = new JetEngine("Jet-Z", 1000, 15000);
        jet.Show();

        // Примусовий виклик GC для демонстрації деструкторів (не гарантує порядок!)
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    static void Task3()
    {
        List<Function> functions = new List<Function>
        {
            new Line(2, 3),
            new Quadratic(1, -2, 1),
            new Hyperbola(5)
        };

        double x = 2;
        foreach (var func in functions)
        {
            func.Show(x);
        }
    }

    static void Task4()
    {
        List<MusicDisc> discs = new List<MusicDisc>
        {
            new MusicDisc("Album1", "AuthorA", 30, 120.0),
            new MusicDisc("Album2", "AuthorB", 45, 100.0),
            new MusicDisc("Album3", "AuthorC", 50, 150.0)
        };

        int targetDuration = 30;
        // Видалити перший елемент з заданою тривалістю
        for (int i = 0; i < discs.Count; i++)
        {
            if (discs[i].Duration == targetDuration)
            {
                discs.RemoveAt(i);
                break;
            }
        }

        // Додати 2 елементи після елемента з номером 0
        if (discs.Count > 0)
        {
            discs.Insert(1, new MusicDisc("NewAlbum1", "NewAuthor1", 40, 90.0));
            discs.Insert(2, new MusicDisc("NewAlbum2", "NewAuthor2", 35, 110.0));
        }

        foreach (var d in discs)
        {
            d.Show();
        }
    }
}
