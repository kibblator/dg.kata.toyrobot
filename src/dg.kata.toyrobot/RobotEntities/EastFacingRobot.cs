using dg.kata.toyrobot.Models;
using dg.kata.toyrobot.Services;

namespace dg.kata.toyrobot.RobotEntities;

public class EastFacingRobot : RobotPosition
{
    private readonly MovementValidator _movementValidator;

    public EastFacingRobot(RobotPosition state, MovementValidator movementValidator) : this(state.X, state.Y,
        state.Robot, movementValidator)
    {
    }

    public EastFacingRobot(int x, int y, Robot robot, MovementValidator movementValidator)
    {
        _movementValidator = movementValidator;
        Direction = Direction.East;
        X = x;
        Y = y;
        Robot = robot;
    }

    public override void Turn(TurnDirection turnDirection)
    {
        if (turnDirection == TurnDirection.Left)
            Robot.State = new NorthFacingRobot(this, _movementValidator);
        else
            Robot.State = new SouthFacingRobot(this, _movementValidator);
    }

    public override void Move()
    {
        if (_movementValidator.CanMove(X + 1, Y))
            X++;
    }
}