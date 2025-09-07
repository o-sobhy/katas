using Microsoft.Win32.SafeHandles;

namespace Katas.TDD.MarsRover;

public class MarsRover()
{
    public required int X { get; set; }
    public required int Y { get; set; }
    public required string Direction { get; set; }
    public int MinimumX { get; set; } = -10;
    public int MaximumX { get; set; } = 10;
    public int MinimumY { get; set; } = -10;
    public int MaximumY { get; set; } = 10;
    public List<(int X, int Y)> Obstacles { get; set; } = new List<(int X, int Y)>();
    
    public string Execute(string commands)
    {
        foreach (var cmd in commands)
        {
            if (cmd == 'L')
            {
                Direction = Direction switch
                {
                    "N" => "W",
                    "W" => "S",
                    "S" => "E",
                    "E" => "N",
                    _ => Direction
                };
            }
        
            else if (cmd == 'R')
            {
                Direction = Direction switch
                {
                    "N" => "E",
                    "E" => "S",
                    "S" => "W",
                    "W" => "N",
                    _ => Direction
                };
            }
        
            else if (cmd == 'M')
            {
                var possibleX = X;
                var possibleY = Y;
                
                switch (Direction)
                {
                    case "N":
                        possibleY = Y + 1 > MaximumY ? MinimumY : Y + 1;
                        break;
                    case "E":
                        possibleX = X + 1 > MaximumX ? MinimumX : X + 1;
                        break;
                    case "S":
                        possibleY = Y - 1 < MinimumY ? MaximumY : Y - 1;
                        break;
                    case "W":
                        possibleX = X - 1 < MinimumX ? MaximumX : X - 1;
                        break;
                }

                if (Obstacles.Contains((possibleX, possibleY)))
                    return $"O:{X}:{Y}:{Direction}";
                
                X = possibleX;
                Y = possibleY;
            }
        }
        
        return $"{X}:{Y}:{Direction}";
    }
    public static void Main()
    {
        Console.WriteLine("Welcome to Mars Rover!");
    }
}