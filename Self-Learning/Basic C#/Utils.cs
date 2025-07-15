namespace Utils;

public class Point
{
    public int X, Y;

    public Point(int x = 0, int y = 0)
    {
        X = x;
        Y = y;
    }
}

public static class Utils
{
    public const uint MAP_WIDTH = 5;
    public const uint MAP_HEIGHT = 5;
    public static Random Randomizer = new();

    public static bool CheckCrash(in Point positionA, in Point positionB)
    {
        if (positionA.X != positionB.X) return false;
        if (positionA.Y != positionB.Y) return false;
        return true;
    }

    public static bool CheckLeftBoundary(in int position)
    {
        if (position <= 0) return true;
        return false;
    }

    public static bool CheckRightBoundary(in int position)
    {
        if (position >= MAP_WIDTH - 3) return true;
        return false;
    }

    public static bool CheckHeightBoundary(in int position)
    {
        if (position >= MAP_HEIGHT - 1) return true;
        return false;
    }
}
