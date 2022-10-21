using dg.kata.toyrobot.Models;

namespace dg.kata.toyrobot.RobotEntities;

public class WestFacingRobot : RobotPosition
{
    public WestFacingRobot(RobotPosition state) : this(state.X, state.Y, state.Robot)
    {
    }
    
    public WestFacingRobot(int x, int y, Robot robot)
    {
        this.Direction = Direction.West;
        this.X = x;
        this.Y = y;
        this.Robot = robot;
    }

    public override void Turn(TurnDirection turnDirection)
    {
        if (turnDirection == TurnDirection.Left)
            Robot.State = new SouthFacingRobot(this);
        else
            Robot.State = new NorthFacingRobot(this);
    }

    public override void Move()
    {
        throw new NotImplementedException();
    }
}