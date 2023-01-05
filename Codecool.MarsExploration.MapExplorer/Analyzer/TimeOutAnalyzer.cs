using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;

namespace Codecool.MarsExploration.MapExplorer.Analyzer;

public class TimeOutAnalyzer : IOutcomeAnalyzer
{
    //if false the simulation should continue
    // if true - simulation stops with TimeOut Outcome
    
    public ExplorationOutcome Analyze(SimulationContext simulationContext, int step)
    {
        
        if (step == simulationContext.StepsToReachTimeOut)
        {
            // Timeout has been reached
            return ExplorationOutcome.Timeout;
        }

        // Timeout has not been reached
        return ExplorationOutcome.InProgress;
    }
}