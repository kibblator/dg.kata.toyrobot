namespace dg.kata.toyrobot.Services;

public class MovementValidator
{
    private readonly int _squareSize;

    public MovementValidator(int squareSize)
    {
        _squareSize = squareSize;
    }


    public bool CanMove(int x, int y)
    {
        return x > -1 && y > -1 && x < _squareSize && y < _squareSize;
    }
}