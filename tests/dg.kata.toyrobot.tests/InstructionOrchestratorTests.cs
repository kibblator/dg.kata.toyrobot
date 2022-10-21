using System;
using System.Collections.Generic;
using System.IO;
using dg.kata.toyrobot.Interfaces;
using dg.kata.toyrobot.Models;
using Moq;
using Xunit;

namespace dg.kata.toyrobot.tests;

public class InstructionOrchestratorTests
{
    private readonly Mock<IGetInstructions> _instructionParserMock;
    private readonly TextWriter _testTextWriter;

    public InstructionOrchestratorTests()
    {
        _testTextWriter = new StringWriter();
        Console.SetOut(_testTextWriter);
        _instructionParserMock = new Mock<IGetInstructions>();
    }
    
    [Fact]
    public void GivenPlaceInstruction_CorrectPositionReported()
    {
        // Arrange
        const string expectedOutput = "4,2,EAST";
        _instructionParserMock.Setup(ip => ip.GetInstructionsFromFile(It.IsAny<string>())).Returns(new List<Instruction>
        {
            new()
            {
                InstructionName = InstructionName.Place,
                X = 4,
                Y = 2,
                Direction = Direction.East
            },
            new()
            {
                InstructionName = InstructionName.Report
            }
        });
        
        var orchestrator = new InstructionOrchestrator(_instructionParserMock.Object);
        
        // Act
        orchestrator.RunInstructions();
        
        //Assert
        Assert.Equal(expectedOutput, _testTextWriter.ToString());
    }

    [Fact]
    public void GivenOtherInstructionsBeforePlace_IgnoresOtherInstructions()
    {
        // Arrange
        const string expectedOutput = "1,1,WEST";
        _instructionParserMock.Setup(ip => ip.GetInstructionsFromFile(It.IsAny<string>())).Returns(new List<Instruction>
        {
            new()
            {
                InstructionName = InstructionName.Report
            },
            new()
            {
                InstructionName = InstructionName.Left
            },
            new()
            {
                InstructionName = InstructionName.Right
            },
            new()
            {
                InstructionName = InstructionName.Move
            },
            new()
            {
                InstructionName = InstructionName.Place,
                X = 1,
                Y = 1,
                Direction = Direction.West
            },
            new()
            {
                InstructionName = InstructionName.Report
            }
        });
        
        var orchestrator = new InstructionOrchestrator(_instructionParserMock.Object);
        
        // Act
        orchestrator.RunInstructions();
        
        //Assert
        Assert.Equal(expectedOutput, _testTextWriter.ToString());
    }
    
    [Fact]
    public void GivenMultiplePlaceCommands_OverridesPreviousMovements()
    {
        // Arrange
        const string expectedOutput = "4,4,NORTH";
        _instructionParserMock.Setup(ip => ip.GetInstructionsFromFile(It.IsAny<string>())).Returns(new List<Instruction>
        {
            new()
            {
                InstructionName = InstructionName.Place,
                X = 1,
                Y = 1,
                Direction = Direction.South
            },
            new()
            {
                InstructionName = InstructionName.Move
            },
            new()
            {
                InstructionName = InstructionName.Right
            },
            new()
            {
                InstructionName = InstructionName.Move
            },
            new()
            {
                InstructionName = InstructionName.Place,
                X = 4,
                Y = 4,
                Direction = Direction.North
            },
            new()
            {
                InstructionName = InstructionName.Report
            }
        });
        
        var orchestrator = new InstructionOrchestrator(_instructionParserMock.Object);
        
        // Act
        orchestrator.RunInstructions();
        
        //Assert
        Assert.Equal(expectedOutput, _testTextWriter.ToString());
    }
    
    [Fact]
    public void GivenMultipleCommands_WalkClockwiseAlmostAFullSquare()
    {
        // Arrange
        const string expectedOutput = "0,0,WEST";
        _instructionParserMock.Setup(ip => ip.GetInstructionsFromFile(It.IsAny<string>())).Returns(new List<Instruction>
        {
            new()
            {
                InstructionName = InstructionName.Place,
                X = 0,
                Y = 0,
                Direction = Direction.North
            },
            new()
            {
                InstructionName = InstructionName.Move
            },
            new()
            {
                InstructionName = InstructionName.Right
            },
            new()
            {
                InstructionName = InstructionName.Move
            },
            new()
            {
                InstructionName = InstructionName.Right
            },
            new()
            {
                InstructionName = InstructionName.Move
            },
            new()
            {
                InstructionName = InstructionName.Right
            },
            new()
            {
                InstructionName = InstructionName.Move
            },
            new()
            {
                InstructionName = InstructionName.Report
            }
        });
        
        var orchestrator = new InstructionOrchestrator(_instructionParserMock.Object);
        
        // Act
        orchestrator.RunInstructions();
        
        //Assert
        Assert.Equal(expectedOutput, _testTextWriter.ToString());
    }
    
    [Fact]
    public void GivenCommands_CannotFallOffTableNorth()
    {
        // Arrange
        const string expectedOutput = "0,4,NORTH";
        _instructionParserMock.Setup(ip => ip.GetInstructionsFromFile(It.IsAny<string>())).Returns(new List<Instruction>
        {
            new()
            {
                InstructionName = InstructionName.Place,
                X = 0,
                Y = 0,
                Direction = Direction.North
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
                InstructionName = InstructionName.Move
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
                InstructionName = InstructionName.Move
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
                InstructionName = InstructionName.Report
            }
        });
        
        var orchestrator = new InstructionOrchestrator(_instructionParserMock.Object);
        
        // Act
        orchestrator.RunInstructions();
        
        //Assert
        Assert.Equal(expectedOutput, _testTextWriter.ToString());
    }
    
    [Fact]
    public void GivenCommands_CannotFallOffTableEast()
    {
        // Arrange
        const string expectedOutput = "4,0,EAST";
        _instructionParserMock.Setup(ip => ip.GetInstructionsFromFile(It.IsAny<string>())).Returns(new List<Instruction>
        {
            new()
            {
                InstructionName = InstructionName.Place,
                X = 3,
                Y = 0,
                Direction = Direction.East
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
                InstructionName = InstructionName.Move
            },
            new()
            {
                InstructionName = InstructionName.Report
            }
        });
        
        var orchestrator = new InstructionOrchestrator(_instructionParserMock.Object);
        
        // Act
        orchestrator.RunInstructions();
        
        //Assert
        Assert.Equal(expectedOutput, _testTextWriter.ToString());
    }
    
    [Fact]
    public void GivenCommands_CannotFallOffTableSouth()
    {
        // Arrange
        const string expectedOutput = "0,0,SOUTH";
        _instructionParserMock.Setup(ip => ip.GetInstructionsFromFile(It.IsAny<string>())).Returns(new List<Instruction>
        {
            new()
            {
                InstructionName = InstructionName.Place,
                X = 0,
                Y = 1,
                Direction = Direction.South
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
                InstructionName = InstructionName.Move
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
                InstructionName = InstructionName.Report
            }
        });
        
        var orchestrator = new InstructionOrchestrator(_instructionParserMock.Object);
        
        // Act
        orchestrator.RunInstructions();
        
        //Assert
        Assert.Equal(expectedOutput, _testTextWriter.ToString());
    }
    
    [Fact]
    public void GivenCommands_CannotFallOffTableWest()
    {
        // Arrange
        const string expectedOutput = "0,0,WEST";
        _instructionParserMock.Setup(ip => ip.GetInstructionsFromFile(It.IsAny<string>())).Returns(new List<Instruction>
        {
            new()
            {
                InstructionName = InstructionName.Place,
                X = 1,
                Y = 0,
                Direction = Direction.West
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
                InstructionName = InstructionName.Move
            },
            new()
            {
                InstructionName = InstructionName.Report
            }
        });
        
        var orchestrator = new InstructionOrchestrator(_instructionParserMock.Object);
        
        // Act
        orchestrator.RunInstructions();
        
        //Assert
        Assert.Equal(expectedOutput, _testTextWriter.ToString());
    }
}