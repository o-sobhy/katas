using Katas.TDD.MarsRover;

namespace Katas.TDD.MarsRover.UnitTests;
public class MarsRoverTests
{
    [Theory]
    [InlineData("N", "W")]
    [InlineData("W", "S")]
    [InlineData("S", "E")]
    [InlineData("E", "N")]
    public void Execute_WhenSingleLeftCommandReceived_ShouldRotate_AndNotMove(string initialDirection, string expectedDirection)
    {
        // Arrange
        var rover = new MarsRover{ X = 0, Y = 0, Direction = initialDirection };
        
        // Act
        rover.Execute("L");
        
        // Assert
        Assert.Equal(expectedDirection, rover.Direction);
        Assert.Equal(0, rover.X);
        Assert.Equal(0, rover.Y);
    }

    [Theory]
    [InlineData("N", "E")]
    [InlineData("E", "S")]
    [InlineData("S", "W")]
    [InlineData("W", "N")]
    public void Execute_WhenSingleRightCommandReceived_ShouldRotate_AndNotMove(string initialDirection,
        string expectedDirection)
    {
        // Arrange
        var rover = new MarsRover { X = 0, Y = 0, Direction = initialDirection };

        // Act
        rover.Execute("R");

        // Assert
        Assert.Equal(expectedDirection, rover.Direction);
        Assert.Equal(0, rover.X);
        Assert.Equal(0, rover.Y);
    }
}