namespace Math;
public delegate double Transformer(double x, double y);

public class Math
{
    public static double Add(double x, double y)
    {
        Console.WriteLine($"{x} + {y}");
        return x + y;
    }

    public static double Substract(double x, double y)
    {
        Console.WriteLine($"{x} - {y}");
        return x - y;
    }

    public static double Multiply(double x, double y)
    {
        Console.WriteLine($"{x} * {y}");
        return x * y;
    }

    public static double Divide(double x, double y)
    {
        Console.WriteLine($"{x} / {y}");
        return x / y;
    }

    public static double GetTubeVolume(double diameter, Transformer multiply, Transformer divide)
    {
        Transformer tubeVolume = (multiply + divide)!;
        tubeVolume -= divide!;
        return tubeVolume!(diameter, 2);
    }
}
