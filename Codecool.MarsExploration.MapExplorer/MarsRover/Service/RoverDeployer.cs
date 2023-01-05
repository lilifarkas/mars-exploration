using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;
using NotImplementedException = System.NotImplementedException;

namespace Codecool.MarsExploration.MapExplorer.MarsRover.Service;

public class RoverDeployer : IRoverDeployer
{
    private readonly CoordinateCalculator _coordinateCalculator;
    
    private static readonly Random Random = new();

    public RoverDeployer(CoordinateCalculator coordinateCalculator)
    {
        _coordinateCalculator = coordinateCalculator;
    }
    public Rover Deploy(Configuration.Configuration configuration)
    {
        int count = 0;
        var adjacentCoordinates = _coordinateCalculator.GetAdjacentCoordinates(configuration.LandingSpot, 1).ToList();
        var visibleTiles = GetVisibleTiles(GetTargetCoordinate(adjacentCoordinates));
        var encounteredResources = new List<Coordinate>();
        foreach (var visibleTile in visibleTiles)
        {
            if (visibleTile != null)
            {
                encounteredResources.Add(visibleTile);
            }
        }

        return new Rover($"rover-{count += 1}", GetTargetCoordinate(adjacentCoordinates), visibleTiles ,encounteredResources);
    }
    
    private Coordinate GetTargetCoordinate(List<Coordinate> coordinates)
    {
        return coordinates.Any()
            ? coordinates[Random.Next(coordinates.Count)]
            : _coordinateCalculator.GetRandomCoordinate(1);
    }
    
    private IEnumerable<Coordinate> GetVisibleTiles(Coordinate coordinate)
    {
        return _coordinateCalculator.GetAdjacentCoordinates(coordinate, 1);
    }
}