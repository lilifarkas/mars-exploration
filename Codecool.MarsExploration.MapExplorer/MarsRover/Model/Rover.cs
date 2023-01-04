using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public record Rover(string Id, Coordinate CurrentPosition, IEnumerable<Coordinate>VisibleTiles, IEnumerable<Coordinate>EncounteredResources);