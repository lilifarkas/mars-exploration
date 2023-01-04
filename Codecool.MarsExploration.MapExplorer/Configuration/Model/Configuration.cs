using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.Configuration;

public record Configuration(string MapFile, Coordinate LandingSpot, IEnumerable<string> SymbolsOfTheResources, int StepsToTimeOut);