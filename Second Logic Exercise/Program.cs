// See https://aka.ms/new-console-template for more information
using Helper;

const int DEFAULT_VALUE = 25;

int x = DEFAULT_VALUE;

if (args.Length >= 1)
{
    x = Convert.ToInt32(args[0]);
}

NumberHolder nh = new();
nh.NumberChanged += Helper.Helper.NumberPrinter;

for (int i = 1; i <= x; i++)
{
    nh.Number = i;
    if (i < x) Console.Write(", ");
}

namespace Helper
{
    public delegate void NumberChangedHandler(int number);

    public class NumberHolder
    {
        int _number = 1;
        public int Number
        {
            get => _number;
            set
            {
                _number = value;
                NumberChanged?.Invoke(_number);
            }
        }
        public NumberChangedHandler? NumberChanged;
    }

    public static class Helper
    {
        public static void NumberPrinter(int x)
        {
            if (x % 3 == 0) Console.Write("foo");
            if (x % 5 == 0) Console.Write("bar");
            if (x % 7 == 0) Console.Write("jazz");
            if (!(x % 3 == 0 || x % 5 == 0 || x % 7 == 0)) Console.Write(x);
        }
    }
}
