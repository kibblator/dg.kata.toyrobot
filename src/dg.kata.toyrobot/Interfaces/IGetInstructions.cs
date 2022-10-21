using dg.kata.toyrobot.Models;

namespace dg.kata.toyrobot.Interfaces;

public interface IGetInstructions
{
    IEnumerable<Instruction> GetInstructionsFromFile(string filePath);
}