using System.Collections.Generic;
using dg.kata.toyrobot.Exceptions;
using dg.kata.toyrobot.Models;
using dg.kata.toyrobot.Services;
using dg.kata.toyrobot.tests.EqualityComparers;
using Xunit;

namespace dg.kata.toyrobot.tests;

public class InstructionParserTests
{
    private readonly InstructionParser _instructionParser;

    public InstructionParserTests()
    {
        _instructionParser = new InstructionParser();
    }
    
    [Fact]
    public void ReadsFileInCorrectFormat_ReturnsCorrectInstructions()
    {
        //Arrange
        var expectedInstructions = new List<Instruction>
        {
            new()
            {
                Direction = Direction.East,
                X = 1,
                Y = 2,
                InstructionName = InstructionName.Place
            },
            new()
            {
                InstructionName = InstructionName.Move
            },
            new()
            {
                InstructionName = InstructionName.Move
            },
            new()
            {
                InstructionName = InstructionName.Left
            },
            new()
            {
                InstructionName = InstructionName.Move
            },
            new()
            {
                InstructionName = InstructionName.Report
            },
            
        };
        
        //Act
        var instructions = _instructionParser.GetInstructionsFromFile("./Resources/InstructionFiles/HappyPath.txt");

        //Assert
        Assert.Equal(expectedInstructions, instructions, new InstructionEqualityComparer());
    }

    [Fact]
    public void ReadsFileWithSpaces_IgnoresSpaces_ReturnsCorrectInput()
    {
        //Arrange
        var expectedInstructions = new List<Instruction>
        {
            new()
            {
                Direction = Direction.North,
                X = 0,
                Y = 0,
                InstructionName = InstructionName.Place
            },
            new()
            {
                InstructionName = InstructionName.Move
            },
            new()
            {
                InstructionName = InstructionName.Report
            }
        };
        
        //Act
        var instructions = _instructionParser.GetInstructionsFromFile("./Resources/InstructionFiles/SpacesBetweenInstructions.txt");
        
        //Assert
        Assert.Equal(expectedInstructions, instructions, new InstructionEqualityComparer());
    }

    [Fact]
    public void ReadsFileWithInvalidInput_ThrowsError()
    {
        //Arrange
        //Act
        ////Assert
        Assert.Throws<InvalidInstructionInputException>(() =>
            _instructionParser.GetInstructionsFromFile("./Resources/InstructionFiles/InvalidInput.txt"));
    }
}