using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.Service;

public interface IExplorationSimulator
{
    void RunSimulation(Configuration.Configuration configuration);
}