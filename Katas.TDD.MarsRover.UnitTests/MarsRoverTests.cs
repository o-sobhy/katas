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

    [Theory]
    [InlineData("N", 0, 1)]
    [InlineData("E", 1, 0)]
    [InlineData("S", 0, -1)]
    [InlineData("W", -1, 0)]
    public void Execute_WhenMoveCommandReceived_ShouldMoveForwardAndNotRotate(string initialDirection, int expectedX, int expectedY)
    {
        // Arrange
        var rover = new MarsRover { X = 0, Y = 0, Direction = initialDirection };
        
        // Act
        rover.Execute("M");
        
        // Assert
        Assert.Equal(initialDirection, rover.Direction);
        Assert.Equal(expectedX, rover.X);
        Assert.Equal(expectedY, rover.Y);
    }
    
    [Fact]
    public void Execute_WhenMultipleCommandsReceived_ShouldProcessCommandsInOrder()
    {
        // Arrange
        var rover = new MarsRover { X = 0, Y = 0, Direction = "N" };
        var commands = "MMRMMRMRRM";
        
        // Act
        rover.Execute(commands);
        
        // Assert
        Assert.Equal(2, rover.X);
        Assert.Equal(2, rover.Y);
        Assert.Equal("N", rover.Direction);
    }
    
    [Theory]
    [InlineData("LLLL")]
    [InlineData("RRRR")]
    public void Execute_WhenFourIdenticalRotationsReceived_ShouldReturnToInitialDirection(string commands)
    {
        // Arrange
        var rover = new MarsRover { X = 0, Y = 0, Direction = "N" };
        
        // Act
        rover.Execute(commands);
        
        // Assert
        Assert.Equal("N", rover.Direction);
        Assert.Equal(0, rover.X);
        Assert.Equal(0, rover.Y);
    }
}