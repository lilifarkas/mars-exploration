using Codecool.MarsExploration.MapExplorer.Simulation.Model;

namespace Codecool.MarsExploration.MapExplorer.Analyzer;

public class LackOfResourcesAnalyzer : IOutcomeAnalyzer
{
    //If false the simulation should continue
    // If true - simulation stops with Error Outcome
    // - analyzer could check whether the rover has almost explored the whole chart and no right condition has been found.

    
    public bool Analize(SimulationContext simulationContext)
    {
        var mapCharts = simulationContext.Map.Representation.GetLength(0) * simulationContext.Map.Representation.GetLength(1);
        var roverExplored = simulationContext.Rover.EncounteredResources.Count();
        
        var countMinerals = simulationContext.Rover.EncounteredResources.Count();
        var countWaters = simulationContext.Rover.EncounteredResources.Count();

        if ((double)roverExplored / mapCharts > 0.7 && countMinerals < 4 && countWaters < 3)
        {
            return true;
        }

        return false;
    }
}