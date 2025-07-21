using System.Numerics;

namespace Generics;

public delegate T Transformer<T>(T val, T multiplier) where T : INumber<T>;
public delegate void Traverser<T>(T[] enumerable) where T : INumber<T>;
public delegate void D1();
public delegate void D2();
public delegate void stringDelegate(string str);

public delegate void ActionObj(object obj);

public static class Generics
{
    public static void Traverse<T>(T[] val)
    {
        for (int i = 0; i < val.Length; i++)
        {
            Console.WriteLine(val[i]);
        }
    }

    public static T TransformMultiply<T>(T val, T multiplier) where T : INumber<T>
    {
        Console.WriteLine($"{val}*{multiplier}");
        return val * multiplier;
    }

    public static void TraverseWith<T>(T[] val, Transformer<T> transformer, T multiplier)
        where T : INumber<T>
    {
        for (int i = 0; i < val.Length; i++)
        {
            val[i] = transformer(val[i], multiplier);
        }
    }

    public static T Transform<T>(T val, T multiplier) where T : INumber<T>
    {
        return val * multiplier;
    }
}

public delegate int Compute(int x);

public class Processor
{
    public int MultiplyBy2(int x)
    {
        Console.WriteLine($"MultiplyBy2 called with {x}");
        return x * 2;
    }

    public int Add10(int x)
    {
        Console.WriteLine($"Add10 called with {x}");
        return x + 10;
    }
}

public delegate void ProgressReport(int percentComplete);

class Progress
{
    public static void Work(ProgressReport pr)
    {
        for (int i = 20; i < 100; i += 15)
        {
            pr(i);
            Thread.Sleep(50);
        }
    }

    public static void WorkWithAction(Action<int> pr)
    {
        Console.WriteLine("Using Action");
        for (int i = 20; i < 100; i += 15)
        {
            pr(i);
            Thread.Sleep(50);
        }
    }
}

// Base and Derived classes
public class Animal (string Name = "Mate")
{
    public string Name = Name;
}
public class Dog : Animal { }
public class Cat : Animal { }

public delegate Animal AnimalFactory();
public delegate Dog DogFactory();
public delegate void DogHandler(Dog dog);
public delegate void CatHandler(Cat cat);

public delegate void A();
public delegate void B();

public struct Point
{
    public int X { get; }
    public int Y { get; }

    // Constructor
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Overload '+' operator
    public static Point operator +(Point a, Point b)
    {
        return new Point(a.X + b.X, a.Y + b.Y);
    }

    // Overload '==' operator
    public static bool operator ==(Point a, Point b)
    {
        return a.X == b.X && a.Y == b.Y;
    }

    // Overload '!=' operator (must be overloaded if '==' is)
    public static bool operator !=(Point a, Point b)
    {
        return !(a == b);
    }

    // Override Equals and GetHashCode when overloading '=='
    public override bool Equals(object obj)
    {
        if (obj is Point other)
            return this == other;
        return false;
    }

    public override int GetHashCode() => (X, Y).GetHashCode();

    public override string ToString() => $"({X}, {Y})";
}