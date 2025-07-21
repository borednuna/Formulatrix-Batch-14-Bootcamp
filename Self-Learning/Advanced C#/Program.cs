// See https://aka.ms/new-console-template for more information
using Generics;
using static Generics.Generics;
using EventHandlers;

// Math.Math m = new();
// Math.Math.GetTubeVolume(2, Math.Math.Multiply, Math.Math.Divide);

// throw new Exception("Throw");

#region NULLABLE

int? x = 5;
int y = (int)x;
Console.WriteLine(y);

int? xNull = null;
int yNull = 0;
// if (xNull.HasValue) yNull = xNull;
yNull = xNull.GetValueOrDefault();
Console.WriteLine(yNull);

// object o = "string";
// int? x = o as int?; // 'o' is not an int, so 'x' becomes null
// Console.WriteLine(x.HasValue); // False

object o = null;
int? check = o as int?;
Console.WriteLine(check.HasValue); // False

Point p1 = new Point(2, 3);
Point p2 = new Point(4, 1);

Point sum = p1 + p2; // Using overloaded '+'
Console.WriteLine($"Sum: {sum}"); // Output: (6, 4)
Console.WriteLine($"Sum int: {1+2}"); // Output: (6, 4)

Console.WriteLine(p1 == p2); // false
Console.WriteLine(p1 != p2); // true

#endregion

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

Func<int, int, int> Multiply = (x, y) => x * y;
Console.WriteLine($"Func Multiply: {Multiply(2, 3)}");

Action<string> LogString = str => Console.WriteLine(str);
LogString("Hello guys welkam bek tu mai cenel");

Channel channel = new();

static void Subscriber1(uint subscriber) => Console.WriteLine($"Subscriber1 now: {subscriber}");
channel.SubscriberChanged += Subscriber1;

channel.AddSubscriber();

static void Subscriber2(uint subscriber) => Console.WriteLine($"Subscriber2 now: {subscriber}");
channel.SubscriberChanged += Subscriber2;
channel.AddSubscriber();

channel.SubscriberChanged -= Subscriber2;

Action postSubscriber1 = () => Console.WriteLine("Subscriber2");
void post_PostUpdated(object sender, StandardPosterEventArgs e)
{
    Console.WriteLine(sender);
    Console.WriteLine(e);
}

Post post = new("First Post");
post.PostUpdated += post_PostUpdated;
post.LastPost = "Test Updating";
Console.WriteLine($"{post.LastPost}");

Processor proc = new();
Compute comp = proc.MultiplyBy2;
comp += proc.Add10;

Console.WriteLine($"Multicast delegate {comp(5)}");

static void ProgressA (int intNum) => Console.WriteLine($"Progress A: {intNum - 5}%");
static void ProgressB (int intNum) => Console.WriteLine($"Progress B: {intNum + 3}%");
static void ProgressC (int intNum) =>  Console.WriteLine($"Progress C: {intNum + 1}%");

ProgressReport pr = ProgressA;
pr += ProgressB;
pr += ProgressC;

Progress.Work(pr);

Action<int> ProgressAction = intNum => Console.WriteLine($"Progress A With Action: {intNum - 5}%");

Progress.WorkWithAction(ProgressAction);

A m1 = Method1;
m1();
B m1b = new(m1);
m1b();

Dog dog = new();
Cat cat = new();
// Parameter compatibility (contravariance)
static void HandleAnimal(Animal animal) => Console.WriteLine($"Handling Animal: {animal.GetType().Name}");
DogHandler dogHandler = HandleAnimal;
dogHandler(dog);
CatHandler catHandler = HandleAnimal;
HandleAnimal(cat);
CatHandler catHandler1 = new CatHandler(HandleAnimal);
catHandler1(cat);

// Return type compatibility (covariance)
static Dog CreateDog() => new Dog();
static Cat CreateCat() => new Cat();
AnimalFactory animalFactory = new AnimalFactory(CreateDog);
AnimalFactory animalFactoryCat = new AnimalFactory(CreateCat);
// AnimalFactory animalFactory = CreateDog;
Console.WriteLine($"Created animal: {animalFactory().GetType().Name}");
Console.WriteLine($"Created animal: {animalFactoryCat().GetType().Name}");

// static Animal CreateAnimal() => new Animal();
// DogFactory dogFactory = new DogFactory(CreateAnimal);

#region TRY_CATCH
try
{
    Console.WriteLine("Main started.");
    FirstMethod();
    Console.WriteLine("Main ended normally.");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Main caught exception: {ex.Message}");
}
finally
{
    Console.WriteLine("Main's finally block executed.");
}

static void FirstMethod()
{
    try
    {
        Console.WriteLine("FirstMethod started.");
        SecondMethod();
        Console.WriteLine("FirstMethod ended normally.");
    }
    finally
    {
        Console.WriteLine("FirstMethod's finally block executed.");
    }
}

static void SecondMethod()
{
    try
    {
        Console.WriteLine("SecondMethod started.");
        ThrowException();
        Console.WriteLine("SecondMethod ended normally.");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"SecondMethod caught exception: {ex.Message}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"SecondMethod caught ArgumentException: {ex.Message}");
    }
    finally
    {
        Console.WriteLine("SecondMethod's finally block executed.");
    }
}

static void ThrowException()
{
    Console.WriteLine("ThrowException about to throw.");
    throw new InvalidOperationException("Something went wrong!");
}

// using StreamReader r = File.OpenText("file.txt");
// Console.WriteLine(r.ReadToEnd());

using (StreamReader r = File.OpenText("file.txt"))
{
    Console.WriteLine(r.ReadToEnd());
}

try
{
    using (StreamReader reader = File.OpenText("filenotfound.txt"))
    {
        string content = reader.ReadToEnd();
        Console.WriteLine(content);
    }
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"File not found: {ex.Message}");
}
finally
{
    Console.WriteLine("Done reading file not found");
}

string Foo() => throw new NotImplementedException();
string ProperCase(string value) =>
    value == null ? throw new ArgumentException("Value cannot be null.") : // Throw in ternary
    value == "" ? "" :
    char.ToUpper(value[0]) + value.Substring(1);

ProperCase("");

try
{
    using StreamReader reader = File.OpenText("filenotfound.txt");
    string content = reader.ReadToEnd();
    Console.WriteLine(content);
}
catch (Exception ex)
{
    // Log the error: ex.Message, ex.StackTrace, etc.
    Console.WriteLine($"Logged error: {ex.Message}");
    // throw; // Rethrows the ORIGINAL exception, preserving its stack trace
}

int number1 = int.Parse("123"); // OK
// int number2 = int.Parse("abc"); // Throws FormatException

// Returns true/false and provides result via 'out' parameter
if (int.TryParse("123", out int result1))
{
    Console.WriteLine($"Parsed: {result1}"); // Output: Parsed: 123
}

if (!int.TryParse("abc", out int result2))
{
    Console.WriteLine("Failed to parse 'abc'."); // Output: Failed to parse 'abc'.
}

#endregion

#region ITERATOR
IEnumerable<int> Fibs(int fibCount) // Returns IEnumerable<int>
{
    for (int i = 0, prevFib = 1, curFib = 1; i < fibCount; i++)
    {
        yield return prevFib; // Yields the current Fibonacci number
        int newFib = prevFib + curFib;
        prevFib = curFib;
        curFib = newFib;
    }
}

IEnumerable<int> EvenNumbersOnly(IEnumerable<int> sequence)
{
    foreach (int x in sequence) // Iterates over the input sequence
    {
        if ((x % 2) == 0)
        {
            yield return x; // Yields only even numbers
        }
    }
}

// ... in your main code:
foreach (int fib in Fibs(6)) // Consumes the sequence produced by Fibs
{
    Console.Write(fib + "  ");
}

static IEnumerable<int> GetNumbers()
{
    Console.WriteLine("GetNumbers started");

    try
    {
        yield return 1;
        yield return 2;
        yield return 3;
    }
    finally
    {
        Console.WriteLine("Finally block executed");
    }
}

foreach (var item in GetNumbers())
{
    Console.WriteLine($"Received: {item}");
    if (item == 2)
        break; // Simulate early exit
}

foreach (int fib in EvenNumbersOnly(Fibs(10))) // Chains Fibs with EvenNumbersOnly
{
    Console.Write(fib + "  ");
}
#endregion
