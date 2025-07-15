using Utils;
using static Utils.Utils;

namespace Entities;

public class Entity
{
    public Point position;

    public Entity()
    {
        position = new Point(1, 4);
    }

    public void MoveRight()
    {
        position.X++;
    }

    public void MoveLeft()
    {
        position.X--;
    }
}

public class Player : Entity
{
    public char character = '\u0697';
}

public class Bush : Entity
{
    public string character = "X";
    public Bush()
    {
        position.X = Randomizer.Next(0, Convert.ToInt32(MAP_WIDTH - 3));
        position.Y = Randomizer.Next(-3, 0);
    }
}
