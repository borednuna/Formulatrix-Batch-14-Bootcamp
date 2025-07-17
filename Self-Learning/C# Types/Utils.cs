namespace Utils;

public struct Coordinates(short x, short y)
{
    public short X = x;
    public short Y = y;
}

public struct CustomDictionary<Tkey, Tvalue>(in Tkey key, in Tvalue value)
{
    public Tkey key = key;
    public Tvalue value = value;
}

public static class Utils
{
    public const uint PARKING_LOT_WIDTH = 10;
    public const uint PARKING_LOT_HEIGHT = 10;
    public enum PublicSpaceStates { Open, Closed, ClosedPermanently };
}
