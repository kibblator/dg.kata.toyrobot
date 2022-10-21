using dg.kata.toyrobot.Models;

namespace dg.kata.toyrobot.RobotEntities;

public class NorthFacingRobot : RobotPosition
{
    public NorthFacingRobot(RobotPosition state) : this(state.X, state.Y, state.Robot)
    {
    }

    public NorthFacingRobot(int x, int y, Robot robot)
    {
        this.Direction = Direction.North;
        this.X = x;
        this.Y = y;
        this.Robot = robot;
    }

    public override void Turn(TurnDirection turnDirection)
    {
        if (turnDirection == TurnDirection.Left)
            Robot.State = new WestFacingRobot(this);
        else
            Robot.State = new EastFacingRobot(this);
    }

    public override void Move()
    {
        Robot.State.Y++;
    }
}