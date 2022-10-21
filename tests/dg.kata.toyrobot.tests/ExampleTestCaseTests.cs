using System;
using System.IO;
using dg.kata.toyrobot.Services;
using Xunit;

namespace dg.kata.toyrobot.tests;

public class ExampleTestCaseTests
{
    private readonly StringWriter _testTextWriter;

    public ExampleTestCaseTests()
    {
        _testTextWriter = new StringWriter();
        Console.SetOut(_testTextWriter);
    }
    
    [Fact]
    public void ReadsFileInCorrectFormat_ReturnsCorrectInstructions()
    {
        //Arrange
        const string expectedOutput = "0,1,NORTH";

        var orchestrator = new InstructionOrchestrator(new InstructionParser(), "./Resources/InstructionFiles/ExampleA.txt");
        
        // Act
        orchestrator.RunInstructions();
        
        //Assert
        Assert.Equal(expectedOutput, _testTextWriter.ToString());
    }

    [Fact]
    public void ReadsFileWithSpaces_IgnoresSpaces_ReturnsCorrectInput()
    {
        //Arrange
        const string expectedOutput = "0,0,WEST";

        var orchestrator = new InstructionOrchestrator(new InstructionParser(), "./Resources/InstructionFiles/ExampleB.txt");
        
        // Act
        orchestrator.RunInstructions();
        
        //Assert
        Assert.Equal(expectedOutput, _testTextWriter.ToString());
    }

    [Fact]
    public void ReadsFileWithInvalidInput_ThrowsError()
    {
        //Arrange
        const string expectedOutput = "3,3,NORTH";

        var orchestrator = new InstructionOrchestrator(new InstructionParser(), "./Resources/InstructionFiles/ExampleC.txt");
        
        // Act
        orchestrator.RunInstructions();
        
        //Assert
        Assert.Equal(expectedOutput, _testTextWriter.ToString());
    }
}