using Utils;
using static Utils.Utils;

namespace PublicSpace;

public interface IPublicSpace
{
    void Close();
    void Open();
    bool IsOpen();
}

public class PublicSpace : IPublicSpace
{
    public string Name { get; }
    public virtual uint Capacity { get; }
    public Coordinates Place;
    public static CustomDictionary<string, string>[] OwnerPlaceMapping { get; set; } = new CustomDictionary<string, string>[10];
    static uint _arrayPos = 2;
    public static uint PublicSpaceTotal { get; set; } = 0;
    PublicSpaceStates _state = PublicSpaceStates.Closed;

    public PublicSpace(in string name, in short placeX, in short placeY)
    {
        Name = name;
        Place.X = placeX;
        Place.Y = placeY;

        OwnerPlaceMapping[0] = new("Nunski", "Foodtruck");
        OwnerPlaceMapping[1] = new("Mas Allan", "TownHall");
        OwnerPlaceMapping[2] = new("Mba Ghinna", "Parking Lot");

        PublicSpaceTotal++;
        Console.WriteLine($"Instantiate Public Space class");
    }

    public void Close()
    {
        Console.WriteLine($"❌ {Name} is Closed");
        _state = PublicSpaceStates.Open;
    }

    public void Open()
    {
        Console.WriteLine($"✅ {Name} is Open");
        _state = PublicSpaceStates.Closed;
    }

    public bool IsOpen() => _state == PublicSpaceStates.Open;

    public static void Info() => Console.WriteLine($"🧑‍🤝‍🧑 There are {PublicSpaceTotal} public spaces in town");

    public static void ViewOwners()
    {
        Console.WriteLine("👀 Viewing owners of places");
        for (int i = 0; i < OwnerPlaceMapping.Length; i++)
        {
            Console.WriteLine($"{i}. {OwnerPlaceMapping[i].key} - {OwnerPlaceMapping[i].value}");
        }
    }

    public static void AddOwners(in string key, in string value)
    {
        if (_arrayPos + 1 == OwnerPlaceMapping.Length)
        {
            Console.WriteLine("⚠️ Owner List is full");
            return;
        }

        OwnerPlaceMapping[++_arrayPos] = new CustomDictionary<string, string>(key, value);
        Console.WriteLine($"✏️ Added {key} to key list");
    }
}
