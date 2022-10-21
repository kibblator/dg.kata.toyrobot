namespace dg.kata.toyrobot.Models;

public class Instruction
{
    public InstructionName InstructionName { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Direction Direction { get; set; }
}