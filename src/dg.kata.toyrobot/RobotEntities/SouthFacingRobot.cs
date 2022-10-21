using dg.kata.toyrobot.Models;
using dg.kata.toyrobot.Services;

namespace dg.kata.toyrobot.RobotEntities;

public class SouthFacingRobot : RobotPosition
{
    private readonly MovementValidator _movementValidator;

    public SouthFacingRobot(RobotPosition state, MovementValidator movementValidator) : this(state.X, state.Y,
        state.Robot, movementValidator)
    {
    }

    public SouthFacingRobot(int x, int y, Robot robot, MovementValidator movementValidator)
    {
        _movementValidator = movementValidator;
        Direction = Direction.South;
        X = x;
        Y = y;
        Robot = robot;
    }

    public override void Turn(TurnDirection turnDirection)
    {
        if (turnDirection == TurnDirection.Left)
            Robot.State = new EastFacingRobot(this, _movementValidator);
        else
            Robot.State = new WestFacingRobot(this, _movementValidator);
    }

    public override void Move()
    {
        if (_movementValidator.CanMove(X, Y - 1))
            Y--;
    }
}