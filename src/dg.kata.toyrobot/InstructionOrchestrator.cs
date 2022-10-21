using dg.kata.toyrobot.Interfaces;
using dg.kata.toyrobot.Models;

namespace dg.kata.toyrobot;

public class InstructionOrchestrator
{
    private readonly List<Instruction> _instructions;

    public InstructionOrchestrator(IGetInstructions instructionParser)
    {
        _instructions = instructionParser.GetInstructions();
    }

    public void RunInstructions()
    {
    }
}