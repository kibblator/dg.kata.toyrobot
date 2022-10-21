namespace dg.kata.toyrobot.Exceptions;

public class InvalidInstructionInputException : Exception
{
    public InvalidInstructionInputException(string filePath, Exception e) : base(
        $"Input in the file {filePath} could not be parsed into an instruction list", e)
    {}
}