using Codecool.MarsExploration.MapExplorer.Simulation.Model;

namespace Codecool.MarsExploration.MapExplorer.Analyzer;

public interface IOutcomeAnalyzer
{
    bool Analize(SimulationContext simulationContext);
}