using Codecool.MarsExploration.MapExplorer.Simulation.Model;

namespace Codecool.MarsExploration.MapExplorer.Analyzer;

public class SuccessAnalyzer : IOutcomeAnalyzer
{
    //If false the simulation should continue
    //If true - It was found that there are 4 minerals and 3 waters found in total - Should stop the simulation with colonizable Outcome
    
    public bool Analize(SimulationContext simulationContext)
    {
        var countMinerals = simulationContext.Rover.EncounteredResources.Count();
        var countWaters = simulationContext.Rover.EncounteredResources.Count();

        if (countMinerals >= 4 && countWaters >= 3)
        {
            return true;
        }

        return false;
    }
}