namespace Katas.TDD.MarsRover;

public class MarsRover()
{
    public required int X { get; set; }
    public required int Y { get; set; }
    public required string Direction { get; set; }
    public int MinimumX { get; set; } = 0;
    public int MaximumX { get; set; } = 10;
    public int MinimumY { get; set; } = 0;
    public int MaximumY { get; set; } = 10;
    
    public void Execute(string commands)
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
                switch (Direction)
                {
                    case "N":
                        Y = Y + 1 > MaximumY ? MinimumY : Y + 1;
                        break;
                    case "E":
                        X = X + 1> MaximumX ? MinimumX : X + 1;
                        break;
                    case "S":
                        Y = Y - 1 < MinimumY ? MaximumY : Y - 1;
                        break;
                    case "W":
                        X = X - 1 < MinimumX ? MaximumX : X - 1;
                        break;
                }
            }
        }
    }
    public static void Main()
    {
        Console.WriteLine("Welcome to Mars Rover!");
    }
}