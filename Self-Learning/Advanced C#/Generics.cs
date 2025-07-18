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