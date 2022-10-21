using dg.kata.toyrobot.Exceptions;
using dg.kata.toyrobot.Interfaces;
using dg.kata.toyrobot.Models;

namespace dg.kata.toyrobot.Services;

public class InstructionParser : IGetInstructions
{
    public IEnumerable<Instruction> GetInstructionsFromFile(string filePath)
    {
        try
        {
            var instructionLines = ReadLinesFromFile(filePath);
            return instructionLines.Select(ConvertTextToInstruction);
        }
        catch (Exception e)
        {
            throw new InvalidInstructionInputException(filePath, e);
        }
    }

    private static Instruction ConvertTextToInstruction(string line)
    {
        var identifier = line.Split(" ")[0].ToLower();

        return identifier switch
        {
            "place" => GetPlaceInstruction(line),
            "move" => new Instruction { InstructionName = InstructionName.Move },
            "report" => new Instruction { InstructionName = InstructionName.Report },
            "left" => new Instruction { InstructionName = InstructionName.Left },
            "right" => new Instruction { InstructionName = InstructionName.Right },
            _ => throw new Exception($"Instruction with identifier '{identifier}' was not recognised")
        };
    }

    private static Instruction GetPlaceInstruction(string line)
    {
        var placeInstructions = line.ToLower().Split("place")[1];
        var placeDetails = placeInstructions.Split(',');

        return new Instruction
        {
            Direction = (Direction)Enum.Parse(typeof(Direction), placeDetails[2].Trim(), true),
            X = Convert.ToInt32(placeDetails[0]),
            Y = Convert.ToInt32(placeDetails[1])
        };
    }

    private static IEnumerable<string> ReadLinesFromFile(string filePath)
    {
        var lines = new List<string>();

        using var reader = new StreamReader(File.OpenRead(filePath));
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (!string.IsNullOrEmpty(line))
                lines.Add(line);
        }

        return lines;
    }
}