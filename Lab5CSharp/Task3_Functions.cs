// ===== Task 3: Abstract Function Hierarchy =====
using System;

abstract class Function {
    public abstract double Compute(double x);
    public virtual void Show(double x) {
        Console.WriteLine($"f({x}) = {Compute(x)}");
    }
}

class Line : Function {
    double a, b;
    public Line(double a, double b) { this.a = a; this.b = b; }
    public override double Compute(double x) => a * x + b;
}

class Quadratic : Function {
    double a, b, c;
    public Quadratic(double a, double b, double c) { this.a = a; this.b = b; this.c = c; }
    public override double Compute(double x) => a * x * x + b * x + c;
}

class Hyperbola : Function {
    double k;
    public Hyperbola(double k) { this.k = k; }
    public override double Compute(double x) => k / x;
}
