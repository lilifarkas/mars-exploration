using Codecool.MarsExploration.MapExplorer.Simulation.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.Service;

public interface IExplorationSimulator
{
    SimulationContext GenerateSimulationContext();
    void RunSimulation(Configuration.Configuration configuration);
    void HandleOutcome();
}