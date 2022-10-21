using dg.kata.toyrobot.Interfaces;
using dg.kata.toyrobot.Models;
using dg.kata.toyrobot.RobotEntities;
using dg.kata.toyrobot.Services;

namespace dg.kata.toyrobot;

public class InstructionOrchestrator
{
    private readonly List<Instruction> _instructions;
    private const int gridSize = 5;

    public InstructionOrchestrator(IGetInstructions instructionParser, string instructionFilePath = "")
    {
        _instructions = instructionParser.GetInstructionsFromFile(instructionFilePath).ToList();
    }

    public void RunInstructions()
    {
        Robot? robot = null;
        foreach (var instruction in _instructions)
        {
            switch(instruction.InstructionName)
            {
                case InstructionName.Place:
                    robot = new Robot(instruction.X, instruction.Y, instruction.Direction,
                        new MovementValidator(gridSize));
                    break;
                case InstructionName.Move:
                    robot?.Move();
                    break;
                case InstructionName.Left:
                    robot?.Turn(TurnDirection.Left);
                    break;
                case InstructionName.Right:
                    robot?.Turn(TurnDirection.Right);
                    break;
                case InstructionName.Report:
                    robot?.Report();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}