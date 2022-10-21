using dg.kata.toyrobot;
using dg.kata.toyrobot.Services;

const string filePath = "./Resources/InstructionFiles/Example.txt";

var orchestrator = new InstructionOrchestrator(new InstructionParser(), filePath);

orchestrator.RunInstructions();