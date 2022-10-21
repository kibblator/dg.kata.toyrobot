using System.Collections.Generic;
using dg.kata.toyrobot.Interfaces;
using dg.kata.toyrobot.Models;
using Moq;
using Xunit;

namespace dg.kata.toyrobot.tests;

public class InstructionOrchestratorTests
{
    private readonly Mock<IGetInstructions> _instructionParserMock;

    public InstructionOrchestratorTests()
    {
        _instructionParserMock = new Mock<IGetInstructions>();
    }
    
    [Fact]
    public void GivenPlaceInstruction_CorrectMethodsCalled()
    {
        // Arrange
        _instructionParserMock.Setup(ip => ip.GetInstructions()).Returns(new List<Instruction>
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
                InstructionName = InstructionName.Left
            },
            new()
            {
                InstructionName = InstructionName.Right
            },
            new()
            {   
                InstructionName = InstructionName.Report
            }
        });
        
        // var orchestrator = new InstructionOrchestrator(_instructionParserMock.Object);
        //
        // // Act
        // orchestrator.RunInstructions();
        //
        // //Assert
        // Assert.That
    }
}