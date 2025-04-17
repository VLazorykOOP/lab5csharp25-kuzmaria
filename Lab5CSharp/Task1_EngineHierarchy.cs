// ===== Task 1: Engine Hierarchy =====
using System;

class Engine {
    public string Model { get; set; }

    public Engine() {
        Model = "Unknown";
        Console.WriteLine("[Engine] Default constructor");
    }

    public Engine(string model) {
        Model = model;
        Console.WriteLine($"[Engine] Constructor with model: {Model}");
    }

    public Engine(Engine other) {
        Model = other.Model;
        Console.WriteLine("[Engine] Copy constructor");
    }

    ~Engine() {
        Console.WriteLine("[Engine] Destructor");
    }

    public virtual void Show() {
        Console.WriteLine($"Engine Model: {Model}");
    }
}

class InternalCombustionEngine : Engine {
    public int CylinderCount { get; set; }

    public InternalCombustionEngine() : base() {
        CylinderCount = 4;
        Console.WriteLine("[ICE] Default constructor");
    }

    public InternalCombustionEngine(string model, int cylinders) : base(model) {
        CylinderCount = cylinders;
        Console.WriteLine("[ICE] Constructor with model and cylinders");
    }

    public InternalCombustionEngine(InternalCombustionEngine other) : base(other) {
        CylinderCount = other.CylinderCount;
        Console.WriteLine("[ICE] Copy constructor");
    }

    ~InternalCombustionEngine() {
        Console.WriteLine("[ICE] Destructor");
    }

    public override void Show() {
        base.Show();
        Console.WriteLine($"Cylinders: {CylinderCount}");
    }
}

class DieselEngine : InternalCombustionEngine {
    public int Torque { get; set; }

    public DieselEngine() : base() {
        Torque = 250;
        Console.WriteLine("[Diesel] Default constructor");
    }

    public DieselEngine(string model, int cylinders, int torque) : base(model, cylinders) {
        Torque = torque;
        Console.WriteLine("[Diesel] Constructor with model, cylinders and torque");
    }

    public DieselEngine(DieselEngine other) : base(other) {
        Torque = other.Torque;
        Console.WriteLine("[Diesel] Copy constructor");
    }

    ~DieselEngine() {
        Console.WriteLine("[Diesel] Destructor");
    }

    public override void Show() {
        base.Show();
        Console.WriteLine($"Torque: {Torque} Nm");
    }
}

class JetEngine : Engine {
    public int Thrust { get; set; }

    public JetEngine() : base() {
        Thrust = 1000;
        Console.WriteLine("[Jet] Default constructor");
    }

    public JetEngine(string model, int thrust) : base(model) {
        Thrust = thrust;
        Console.WriteLine("[Jet] Constructor with model and thrust");
    }

    public JetEngine(JetEngine other) : base(other) {
        Thrust = other.Thrust;
        Console.WriteLine("[Jet] Copy constructor");
    }

    ~JetEngine() {
        Console.WriteLine("[Jet] Destructor");
    }

    public override void Show() {
        base.Show();
        Console.WriteLine($"Thrust: {Thrust} kN");
    }
}
