using Xunit;
using static Katas.TDD.FizzBuzz.FizzBuzzSolver;

namespace Katas.TDD.FizzBuzz.UnitTests;

public class FizzBuzzTests
{
    [Fact]
    public void Solve_WhenNotMultipleOfThreeNorFive_ShouldReturnNumberAsString()
    {
        // Arrange
        int number = 7;

        // Act
        string result = FizzBuzzSolver.Solve(number);

        // Assert
        Assert.Equal("7", result);
    }
    
    [Fact]
    public void Solve_WhenMultipleOfThreeAndFive_ShouldReturnFizzBuzz()
    {
        // Arrange
        int number = 15;
        
        // Act
        string result = Solve(number);
        
        // Assert
        Assert.Equal("FizzBuzz", result);
    }
}