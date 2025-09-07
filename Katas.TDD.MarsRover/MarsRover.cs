namespace Katas.TDD.MarsRover;

public class MarsRover()
{
    public required int X { get; set; }
    public required int Y { get; set; }
    public required string Direction { get; set; }
    
    public void Execute(string command)
    {
        if (command.Equals("L"))
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
        
        else if (command.Equals("R"))
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
    }
    public static void Main()
    {
        Console.WriteLine("Welcome to Mars Rover!");
    }
}