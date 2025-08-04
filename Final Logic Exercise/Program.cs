// See https://aka.ms/new-console-template for more information

const int DEFAULT_VALUE = 25;

int x = DEFAULT_VALUE;

if (args.Length >= 1)
{
    x = Convert.ToInt32(args[0]);
}

NumberHelper helperClass = new();
helperClass.PrintSequence(x);
helperClass.AddRule(2, "bee");
helperClass.PrintSequence(x);

#region NUMBER_HELPER_CLASS
public class NumberHelper
{
    private SortedDictionary<int, string> _rules = [];

    public NumberHelper()
    {
        _rules[3] = "foo";
        _rules[4] = "baz";
        _rules[5] = "bar";
        _rules[7] = "jazz";
        _rules[9] = "huzz";
    }

    public void PrintSequence(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            bool isPrinted = false;

            foreach (var integerStringPair in _rules)
            {
                if (i % integerStringPair.Key == 0)
                {
                    Console.Write(integerStringPair.Value);
                    isPrinted = true;
                }
            }

            if (!isPrinted) Console.Write(i);
            if (i < n) Console.Write(", ");
        }
        Console.WriteLine();
    }

    public void AddRule(int input, string output)
    {
        if (_rules.ContainsKey(input))
        {
            Console.WriteLine("Key already exist");
            return;
        }
        _rules[input] = output;
    }
}
#endregion
