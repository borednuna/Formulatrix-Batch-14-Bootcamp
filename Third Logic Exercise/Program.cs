// See https://aka.ms/new-console-template for more information

const int DEFAULT_VALUE = 25;

uint x = DEFAULT_VALUE;

if (args.Length >= 1)
{
    x = Convert.ToUInt32(args[0]);
}

for (uint i = 1; i <= x; i++)
{
    bool printedAlias = default;
    if (i % 3 == 0)
    {
        Console.Write("foo");
        printedAlias = true;
    }
    if (i % 4 == 0)
    {
        Console.Write("baz");
        printedAlias = true;
    }
    if (i % 5 == 0)
    {
        Console.Write("bar");
        printedAlias = true;
    }
    if (i % 7 == 0)
    {
        Console.Write("jazz");
        printedAlias = true;
    }
    if (i % 9 == 0)
    {
        Console.Write("huzz");
        printedAlias = true;
    }
    if (!printedAlias) Console.Write(i);

    if (i < x) Console.Write(", ");
}