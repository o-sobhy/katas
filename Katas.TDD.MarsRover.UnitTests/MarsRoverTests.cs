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
        var rover = new MarsRover(initialDirection);
        
        // Act
        rover.Execute("L");
        
        // Assert
        Assert.Equal(expectedDirection, rover.Direction);
        Assert.Equal(0, rover.X);
        Assert.Equal(0, rover.Y);
    }
}