using dg.kata.toyrobot.Models;
using dg.kata.toyrobot.RobotEntities;
using Xunit;

namespace dg.kata.toyrobot.tests;

public class RobotTests
{
    [Theory]
    [InlineData(TurnDirection.Left, Direction.West)]
    [InlineData(TurnDirection.Right, Direction.East)]
    public void GivenANorthFacingRobot_WhenTurnIsCalled_AppropriateRobotIsReturned(TurnDirection turnDirection,
        Direction expectedRobotFacing)
    {
        //Arrange
        const int x = 0, y = 0;
        var robot = new Robot(x, y, Direction.North);

        //Act
        robot.Turn(turnDirection);

        //Assert
        Assert.Equal(expectedRobotFacing, robot.State.Direction);
    }
    
    [Theory]
    [InlineData(TurnDirection.Left, Direction.North)]
    [InlineData(TurnDirection.Right, Direction.South)]
    public void GivenAnEastFacingRobot_WhenTurnIsCalled_AppropriateRobotIsReturned(TurnDirection turnDirection,
        Direction expectedRobotFacing)
    {
        //Arrange
        const int x = 0, y = 0;
        var robot = new Robot(x, y, Direction.East);

        //Act
        robot.Turn(turnDirection);

        //Assert
        Assert.Equal(expectedRobotFacing, robot.State.Direction);
    }
    
    [Theory]
    [InlineData(TurnDirection.Left, Direction.East)]
    [InlineData(TurnDirection.Right, Direction.West)]
    public void GivenASouthFacingRobot_WhenTurnIsCalled_AppropriateRobotIsReturned(TurnDirection turnDirection,
        Direction expectedRobotFacing)
    {
        //Arrange
        const int x = 0, y = 0;
        var robot = new Robot(x, y, Direction.South);

        //Act
        robot.Turn(turnDirection);

        //Assert
        Assert.Equal(expectedRobotFacing, robot.State.Direction);
    }
    
    [Theory]
    [InlineData(TurnDirection.Left, Direction.South)]
    [InlineData(TurnDirection.Right, Direction.North)]
    public void GivenAWestFacingRobot_WhenTurnIsCalled_AppropriateRobotIsReturned(TurnDirection turnDirection,
        Direction expectedRobotFacing)
    {
        //Arrange
        const int x = 0, y = 0;
        var robot = new Robot(x, y, Direction.West);

        //Act
        robot.Turn(turnDirection);

        //Assert
        Assert.Equal(expectedRobotFacing, robot.State.Direction);
    }
}