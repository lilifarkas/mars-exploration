using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;

namespace Codecool.MarsExploration.MapExplorer.Analyzer;

public interface IOutcomeAnalyzer
{
    ExplorationOutcome Analyze(SimulationContext simulationContext);
}