using dg.kata.toyrobot.Models;

namespace dg.kata.toyrobot.RobotEntities;

public class EastFacingRobot : RobotPosition
{
    public EastFacingRobot(RobotPosition state) : this(state.X, state.Y, state.Robot)
    {
    }

    public EastFacingRobot(int x, int y, Robot robot)
    {
        this.Direction = Direction.East;
        this.X = x;
        this.Y = y;
        this.Robot = robot;
    }

    public override void Turn(TurnDirection turnDirection)
    {
        if (turnDirection == TurnDirection.Left)
            Robot.State = new NorthFacingRobot(this);
        else
            Robot.State = new SouthFacingRobot(this);
    }

    public override void Move()
    {
        throw new NotImplementedException();
    }
}