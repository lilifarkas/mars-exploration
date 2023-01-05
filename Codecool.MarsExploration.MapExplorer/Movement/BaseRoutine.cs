using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;

namespace Codecool.MarsExploration.MapExplorer.Movement;

public abstract class BaseRoutine
{
    private readonly CoordinateCalculator _coordinateCalculator;
    
    private readonly Configuration.Configuration _configuration;

    private readonly MapLoader.MapLoader _mapLoader;

    protected BaseRoutine(CoordinateCalculator coordinateCalculator, Configuration.Configuration configuration, MapLoader.MapLoader mapLoader)
    {
        _coordinateCalculator = coordinateCalculator;
        _configuration = configuration;
        _mapLoader = mapLoader;
    }

    protected void Move(Rover rover,Coordinate coordinate)
    {
        rover.CurrentPosition = coordinate;
    }

    protected void Scan(Rover rover)
    {
        rover.VisibleTiles = _coordinateCalculator.GetAdjacentCoordinates(rover.CurrentPosition, 1);
        
        var map = _mapLoader.Load(_configuration.MapFile);
        
        var resources = rover.EncounteredResources.ToList();
        
        foreach (var visibleTile in rover.VisibleTiles)
        {
            if (_configuration.SymbolsOfTheResources.Contains(map.Representation[visibleTile.X,visibleTile.Y]))
            {
                resources.Add(visibleTile);
            }
        }

        rover.EncounteredResources = resources;
    }

    public abstract void Step(Rover rover);
}