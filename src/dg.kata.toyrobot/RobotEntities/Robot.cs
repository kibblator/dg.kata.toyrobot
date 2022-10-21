using dg.kata.toyrobot.Models;

namespace dg.kata.toyrobot.RobotEntities;

public class Robot
{
    public RobotPosition State { get; set; }

    public Robot(int x, int y, Direction initialDirection)
    {
        State = initialDirection switch
        {
            Direction.North => new NorthFacingRobot(x, y, this),
            Direction.East => new EastFacingRobot(x, y, this),
            Direction.South => new SouthFacingRobot(x, y, this),
            Direction.West => new WestFacingRobot(x, y, this),
            _ => throw new ArgumentOutOfRangeException(nameof(initialDirection), initialDirection, null)
        };
    }

    public void Turn(TurnDirection turnDirection)
    {
        State.Turn(turnDirection);
    }
}