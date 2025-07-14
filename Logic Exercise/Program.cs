// See https://aka.ms/new-console-template for more information

class Program
{
    public const int DEFAULT_VALUE = 25;

    static void Main(string[] args)
    {
        uint x = DEFAULT_VALUE;

        if (args.Length > 1)
        {
            x = Convert.ToUInt32(args[0]);
        }

        for (uint i = 1; i <= x; i++)
        {
            switch (i)
            {
                case uint j when j % 15 == 0:
                    Console.Write("foobar");
                    break;
                case uint j when j % 3 == 0:
                    Console.Write("foo");
                    break;
                case uint j when j % 5 == 0:
                    Console.Write("bar");
                    break;
                default:
                    Console.Write(i);
                    break;
            }

            if (i < x) Console.Write(", ");
        }
    }
}