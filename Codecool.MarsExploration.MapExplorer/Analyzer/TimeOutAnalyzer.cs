using Codecool.MarsExploration.MapExplorer.Simulation.Model;

namespace Codecool.MarsExploration.MapExplorer.Analyzer;

public class TimeOutAnalyzer : IOutcomeAnalyzer
{
    //if false the simulation should continue
    // if true - simulation stops with TimeOut Outcome
    
    public bool Analize(SimulationContext simulationContext)
    {
        if (simulationContext.Step >= simulationContext.StepsToReachTimeOut)
        {
            // Timeout has been reached
            return true;
        }

        // Timeout has not been reached
        return false;
    }
}