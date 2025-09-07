namespace Katas.TDD.FizzBuzz;

public class FizzBuzzSolver
{
    public static string Solve(int number)
    {
        if (number % 3 == 0 && number % 5 == 0)
            return "FizzBuzz";
        if (number % 3 == 0)
            return "Fizz";
        return number.ToString();
    }
    
    public static void Main()
    {
        Console.WriteLine("Welcome to FizzBuzz!");
    }
}