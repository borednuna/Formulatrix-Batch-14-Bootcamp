// See https://aka.ms/new-console-template for more information
using Generics;
using static Generics.Generics;

// Math.Math m = new();
// Math.Math.GetTubeVolume(2, Math.Math.Multiply, Math.Math.Divide);

int[] ints = [3, 4, 5];

for (int i = 0; i < ints.Length; i++)
{
    Console.Write($"{ints[i]}, ");
}
Console.WriteLine();

Transformer<int> transformer = TransformMultiply;
TraverseWith(ints, transformer, 3);

for (int i = 0; i < ints.Length; i++)
{
    Console.Write($"{ints[i]}, ");
}
Console.WriteLine();

static void Method1() => Console.WriteLine("Method1");

// Variance
D1 d1 = Method1;
D2 d2 = new(d1);

d2();

static void ActionObj(object obj) => Console.WriteLine(obj.ToString());

stringDelegate strDelegate = ActionObj;
strDelegate("Object String Delegate");