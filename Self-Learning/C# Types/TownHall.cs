namespace PublicSpace.TownHall;

public class TownHall : PublicSpace
{
    public static uint TownHallTotal { get; set; } = 0;

    public TownHall(in string name, in short placeX = 0, in short placeY = 0)
        : base(name, placeX, placeY)
    {
        TownHallTotal++;
        Console.WriteLine($"Instantiate TownHall object");
    }

    public static new void Info() => Console.WriteLine($"🏰 There are {TownHallTotal} parking lots in town");
}