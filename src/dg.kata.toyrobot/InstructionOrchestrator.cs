using dg.kata.toyrobot.Interfaces;
using dg.kata.toyrobot.Models;

namespace dg.kata.toyrobot;

public class InstructionOrchestrator
{
    private readonly List<Instruction> _instructions;

    public InstructionOrchestrator(IGetInstructions instructionParser, string instructionFilePath = "")
    {
        _instructions = instructionParser.GetInstructionsFromFile(instructionFilePath).ToList();
    }

    public string RunInstructions()
    {
        
        
        return "";
    }
}