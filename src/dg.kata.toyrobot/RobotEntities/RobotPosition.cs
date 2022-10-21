using dg.kata.toyrobot.Models;

namespace dg.kata.toyrobot.RobotEntities;

public abstract class RobotPosition
{
    public int X { get; set; }
    public int Y { get; set; }
    public Direction Direction { get; set; }
    public Robot Robot { get; set; }

    public abstract void Turn(TurnDirection turnDirection);
    public abstract void Move();
    
    public string Report()
    {
        throw new NotImplementedException();
    }
}