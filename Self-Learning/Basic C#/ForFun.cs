using Entities;
using static Utils.Utils;

namespace ForFun;

public class ProgramLoop
{
    private Player _player;
    private string _userInput = "s";
    private Bush[] _bushes = new Bush[5];

    public ProgramLoop()
    {
        _player = new();

        for (int i = 0; i < 5; i++)
        {
            _bushes[i] = new();
        }
    }

    public void Start()
    {
        while (true)
        {
            MapWriter();
        }
    }

    private void MapWriter()
    {
        for (int i = 0; i < MAP_HEIGHT; i++)
        {
            Console.Write('|');
            for (int j = 0; j < MAP_WIDTH - 2; j++)
            {
                bool isBush = default;
                for (int k = 0; k < 5; k++)
                {
                    if (i == _bushes[k].position.Y && j == _bushes[k].position.X)
                    {
                        Console.Write(_bushes[k].character);
                        isBush = true;
                    }
                }

                if (!isBush)
                {
                    if (i == _player.position.Y && j == _player.position.X)
                    {
                        Console.Write(_player.character);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
            }

            Console.WriteLine('|');
        }

        _userInput = Console.ReadLine() ?? "s";
        // Sleep(500);
        Console.Clear();

        if (_userInput == "a")
        {
            if (!CheckLeftBoundary(_player.position.X)) _player.MoveLeft();
        }
        else if (_userInput == "d")
        {
            if (!CheckRightBoundary(_player.position.X)) _player.MoveRight();
        }

        for (int i = 0; i < 5; i++)
        {
            _bushes[i].position.Y++;
        }

        // for (int k = 0; k < 5; k++)
        // {
        //     Console.Write(_bushes[k].character);
        // }
    }
}
