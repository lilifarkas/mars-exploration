using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;

namespace Codecool.MarsExploration.MapExplorer.Movement;

public abstract class BaseRoutine
{
    private readonly CoordinateCalculator _coordinateCalculator;

    public BaseRoutine(CoordinateCalculator coordinateCalculator)
    {
        _coordinateCalculator = coordinateCalculator;
    }
    
    public void Move(Rover rover,int x, int y)
    {
        rover.CurrentPosition = new Coordinate(x, y);
    }

    public void Scan(Rover rover)
    {
        var map = 
        rover.VisibleTiles = _coordinateCalculator.GetAdjacentCoordinates(rover.CurrentPosition, 1);
        var resources = rover.EncounteredResources;
        foreach (var visibleTile in rover.VisibleTiles)
        {
            if (visibleTile != null)
            {
                
            }
        }
    }

    public abstract void Run(Rover rover);
}