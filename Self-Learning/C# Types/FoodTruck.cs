using Utils;

namespace PublicSpace.Moveable;

public class FoodTruck : PublicSpace, IMoveble
{
    public static uint FoodTruckTotal { get; set; } = 0;
    public CustomDictionary<string, object>[] menu = new CustomDictionary<string, object>[10];
    public FoodTruck(in string name, in short placeX = 0, in short placeY = 0)
        : base(name, placeX, placeY)
    {
        menu[0] = new CustomDictionary<string, object>("Chicken Katsu", 13000);
        menu[1] = new CustomDictionary<string, object>("Chicken Karage", 17000);
        menu[2] = new CustomDictionary<string, object>("Gyoza", "Unavailable");

        FoodTruckTotal++;
        Console.WriteLine($"Instantiate Moveable Foodtruck object");
    }
    public void Move(in short stepX, in short stepY)
    {
        Place.X += stepX;
        Place.Y += stepY;

        Console.WriteLine($"🚛 Moving {Name} foodtruck by {stepX}x and {stepY}y");
    }

    public void ViewMenu()
    {
        Console.WriteLine("🍱 Viewing Foodtruck Menu");
        for (int i = 0; i < menu.Length; i++)
        {
            Console.WriteLine($"{i}. {menu[i].key}: {menu[i].value}");
        }
    }

    void IMoveble.Info() => Console.WriteLine($"🍛 Food truck {Name} is now at ({Place.X}, {Place.Y})");
    public new static void Info() => Console.WriteLine($"🍛 There are {FoodTruckTotal} food trucks in town");
}
