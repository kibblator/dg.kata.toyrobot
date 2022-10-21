using dg.kata.toyrobot.Models;
using dg.kata.toyrobot.Services;

namespace dg.kata.toyrobot.RobotEntities;

public class NorthFacingRobot : RobotPosition
{
    private readonly MovementValidator _movementValidator;

    public NorthFacingRobot(RobotPosition state, MovementValidator movementValidator) : this(state.X, state.Y,
        state.Robot, movementValidator)
    {
    }

    public NorthFacingRobot(int x, int y, Robot robot, MovementValidator movementValidator)
    {
        _movementValidator = movementValidator;
        Direction = Direction.North;
        X = x;
        Y = y;
        Robot = robot;
    }

    public override void Turn(TurnDirection turnDirection)
    {
        if (turnDirection == TurnDirection.Left)
            Robot.State = new WestFacingRobot(this, _movementValidator);
        else
            Robot.State = new EastFacingRobot(this, _movementValidator);
    }

    public override void Move()
    {
        if (_movementValidator.CanMove(X, Y + 1))
            Robot.State.Y++;
    }
}