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
        var loc = rover.Execute("L");
        
        // Assert
        Assert.Equal($"0:0:{expectedDirection}", loc);
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
        var loc = rover.Execute("R");

        // Assert
        Assert.Equal($"0:0:{expectedDirection}", loc);
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
        var expectedDirection = initialDirection;
        
        // Act
        var loc = rover.Execute("M");
        
        // Assert
        Assert.Equal($"{expectedX}:{expectedY}:{expectedDirection}", loc);
    }
    
    [Fact]
    public void Execute_WhenMultipleCommandsReceived_ShouldProcessCommandsInOrder()
    {
        // Arrange
        var rover = new MarsRover { X = 0, Y = 0, Direction = "N" };
        var commands = "MMRMMRMRRM";
        
        // Act
        var loc = rover.Execute(commands);
        
        // Assert
        Assert.Equal($"2:2:N", loc);
    }
    
    [Theory]
    [InlineData("LLLL")]
    [InlineData("RRRR")]
    public void Execute_WhenFourIdenticalRotationsReceived_ShouldReturnToInitialDirection(string commands)
    {
        // Arrange
        var rover = new MarsRover { X = 0, Y = 0, Direction = "N" };
        
        // Act
        var loc = rover.Execute(commands);
        
        // Assert
        Assert.Equal($"0:0:N", loc);
    }
    
    [Theory]
    [InlineData(5, 10, "N", 5, 0)]
    [InlineData(10, 5, "E", 0, 5)]
    [InlineData(5, -10, "S", 5, 10)]
    [InlineData(-10, 5, "W", 10, 5)]
    public void Execute_WhenMovingBeyondGridBoundaries_ShouldWrapAround(int initialX, int initialY, string initialDirection, int expectedX, int expectedY)
    {
        // Arrange
        var rover = new MarsRover { X = initialX, Y = initialY, Direction = initialDirection, MinimumX = 0, MaximumX = 10, MinimumY = 0, MaximumY = 10 };
        var expectedDirection = initialDirection;
        
        // Act
        var loc = rover.Execute("M");
        
        // Assert
        Assert.Equal($"{expectedX}:{expectedY}:{expectedDirection}", loc);
    }
}