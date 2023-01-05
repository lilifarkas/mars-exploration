using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;

namespace Codecool.MarsExploration.MapExplorer.Movement;

public class ExploringRoutine : BaseRoutine
{
    private readonly CoordinateCalculator _coordinateCalculator;
    
    private readonly Configuration.Configuration _configuration;

    private readonly MapLoader.MapLoader _mapLoader;
    
    private static readonly Random Random = new();
    public ExploringRoutine(CoordinateCalculator coordinateCalculator, Configuration.Configuration configuration, MapLoader.MapLoader mapLoader) : base(coordinateCalculator,configuration,mapLoader)
    {
        _coordinateCalculator = coordinateCalculator;
        _configuration = configuration;
        _mapLoader = mapLoader;
    }

    public override void Step(Rover rover)
    {
        var emptyTiles = new List<Coordinate>();
        
        var map = _mapLoader.Load(_configuration.MapFile);
        
        foreach (var visibleTile in rover.VisibleTiles)
        {
            if (map.IsEmpty(visibleTile))
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