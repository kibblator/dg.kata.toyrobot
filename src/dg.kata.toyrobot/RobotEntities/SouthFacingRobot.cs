using dg.kata.toyrobot.Models;

namespace dg.kata.toyrobot.RobotEntities;

public class SouthFacingRobot : RobotPosition
{
    public SouthFacingRobot(RobotPosition state) : this(state.X, state.Y, state.Robot)
    {
    }
    
    public SouthFacingRobot(int x, int y, Robot robot)
    {
        this.Direction = Direction.South;
        this.X = x;
        this.Y = y;
        this.Robot = robot;
    }

    public override void Turn(TurnDirection turnDirection)
    {
        if (turnDirection == TurnDirection.Left)
            Robot.State = new EastFacingRobot(this);
        else
            Robot.State = new WestFacingRobot(this);
    }

    public override void Move()
    {
        throw new NotImplementedException();
    }
}