// See https://aka.ms/new-console-template for more information
using Generics;
using static Generics.Generics;
using EventHandlers;

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