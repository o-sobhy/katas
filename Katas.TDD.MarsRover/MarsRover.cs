namespace Katas.TDD.MarsRover;

public class MarsRover()
{
    public required int X { get; set; }
    public required int Y { get; set; }
    public required string Direction { get; set; }
    
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
                        Y += 1;
                        break;
                    case "E":
                        X += 1;
                        break;
                    case "S":
                        Y -= 1;
                        break;
                    case "W":
                        X -= 1;
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