using Utils;
using static Utils.Utils;

namespace PublicSpace.ParkingLot;

public class ParkingLot : PublicSpace
{
    public static uint ParkingLotTotal { get; set; } = 0;
    public uint Fee { get; } = 3000;
    public override uint Capacity { get => PARKING_LOT_HEIGHT * PARKING_LOT_WIDTH; }

    public ParkingLot(in string name, in short placeX = 0, in short placeY = 0)
        : base(name, placeX, placeY)
    {
        ParkingLotTotal++;
        Console.WriteLine($"Instantiate ParkingLot object");
    }

    public static new void Info() => Console.WriteLine($"🅿️ There are {ParkingLotTotal} parking lots in town");
}
