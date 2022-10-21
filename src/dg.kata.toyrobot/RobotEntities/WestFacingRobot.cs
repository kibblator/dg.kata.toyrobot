using dg.kata.toyrobot.Models;
using dg.kata.toyrobot.Services;

namespace dg.kata.toyrobot.RobotEntities;

public class WestFacingRobot : RobotPosition
{
    private readonly MovementValidator _movementValidator;

    public WestFacingRobot(RobotPosition state, MovementValidator movementValidator) : this(state.X, state.Y,
        state.Robot, movementValidator)
    {
    }

    public WestFacingRobot(int x, int y, Robot robot, MovementValidator movementValidator)
    {
        _movementValidator = movementValidator;
        Direction = Direction.West;
        X = x;
        Y = y;
        Robot = robot;
    }

    public override void Turn(TurnDirection turnDirection)
    {
        if (turnDirection == TurnDirection.Left)
            Robot.State = new SouthFacingRobot(this, _movementValidator);
        else
            Robot.State = new NorthFacingRobot(this, _movementValidator);
    }

    public override void Move()
    {
        if (_movementValidator.CanMove(X - 1, Y))
            X--;
    }
}