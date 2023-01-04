using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;
using NotImplementedException = System.NotImplementedException;

namespace Codecool.MarsExploration.MapExplorer.MarsRover.Service;

public class RoverDeployer : IRoverDeployer
{
    private static readonly Random Random = new();
    public Rover Deploy(Configuration.Configuration configuration, CoordinateCalculator coordinateCalculator)
    {
        int count = 0;
        var adjacentCoordinates = coordinateCalculator.GetAdjacentCoordinates(configuration.LandingSpot, 1).ToList();
        var visibleTiles = GetVisibleTiles(GetTargetCoordinate(adjacentCoordinates, coordinateCalculator),
            coordinateCalculator);
        var encounteredResources = new List<Coordinate>();
        foreach (var visibleTile in visibleTiles)
        {
            if (visibleTile != null)
            {
                encounteredResources.Add(visibleTile);
            }
        }

        return new Rover($"rover-{count += 1}", GetTargetCoordinate(adjacentCoordinates, coordinateCalculator), visibleTiles,
            encounteredResources);
    }
    
    private Coordinate GetTargetCoordinate(List<Coordinate> coordinates, CoordinateCalculator coordinateCalculator)
    {
        return coordinates.Any()
            ? coordinates[Random.Next(coordinates.Count)]
            : coordinateCalculator.GetRandomCoordinate(1);
    }
    
    private IEnumerable<Coordinate> GetVisibleTiles(Coordinate coordinate, CoordinateCalculator coordinateCalculator)
    {
        return coordinateCalculator.GetAdjacentCoordinates(coordinate, 1);
    }
}