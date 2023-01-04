using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.Model;

public record Configuration(int Step, int StepsToReachTimeOut, Rover Rover, Coordinate LocationOfTheSpaceship, Map Map, IEnumerable<string> SymbolsToLookFor, ExplorationOutcome ExplorationOutcome);
