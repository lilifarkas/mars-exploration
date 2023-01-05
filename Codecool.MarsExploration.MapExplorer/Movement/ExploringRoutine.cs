using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;

namespace Codecool.MarsExploration.MapExplorer.Movement;

public class ExploringRoutine : BaseRoutine
{
    private readonly CoordinateCalculator _coordinateCalculator;
    
    private static readonly Random Random = new();
    public ExploringRoutine(CoordinateCalculator coordinateCalculator) : base(coordinateCalculator)
    {
        _coordinateCalculator = coordinateCalculator;
    }

    public override void Step(Rover rover)
    {
        var emptyTiles = new List<Coordinate>();

        foreach (var visibleTile in rover.VisibleTiles)
        {
            if (visibleTile == null)
            {
                emptyTiles.Add(visibleTile);
            }
        }
        var randomCoordinate = GetTargetCoordinate(emptyTiles);
        
        Move(rover, randomCoordinate);
        Scan(rover);
    }
    
    private Coordinate GetTargetCoordinate(List<Coordinate> coordinates)
    {
        return coordinates.Any()
            ? coordinates[Random.Next(coordinates.Count)]
            : _coordinateCalculator.GetRandomCoordinate(1);
    }
}