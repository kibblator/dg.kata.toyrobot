using dg.kata.toyrobot.Models;
using dg.kata.toyrobot.Services;

namespace dg.kata.toyrobot.RobotEntities;

public class Robot
{
    public RobotPosition State { get; set; }

    public Robot(int x, int y, Direction initialDirection, MovementValidator movementValidator)
    {
        State = initialDirection switch
        {
            Direction.North => new NorthFacingRobot(x, y, this, movementValidator),
            Direction.East => new EastFacingRobot(x, y, this, movementValidator),
            Direction.South => new SouthFacingRobot(x, y, this, movementValidator),
            Direction.West => new WestFacingRobot(x, y, this, movementValidator),
            _ => throw new ArgumentOutOfRangeException(nameof(initialDirection), initialDirection, null)
        };
    }

    public void Turn(TurnDirection turnDirection)
    {
        State.Turn(turnDirection);
    }

    public void Move()
    {
        State.Move();
    }

    public void Report()
    {
        State.Report();
    }
}