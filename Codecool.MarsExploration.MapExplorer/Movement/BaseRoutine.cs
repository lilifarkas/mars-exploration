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
    
    public void Move(Rover rover,Coordinate coordinate)
    {
        rover.CurrentPosition = coordinate;
    }

    public void Scan(Rover rover)
    {
        rover.VisibleTiles = _coordinateCalculator.GetAdjacentCoordinates(rover.CurrentPosition, 1);
        var resources = rover.EncounteredResources.ToList();
        foreach (var visibleTile in rover.VisibleTiles)
        {
            if (visibleTile != null)
            {
                resources.Add(visibleTile);
            }
        }

        rover.EncounteredResources = resources;
    }

    public abstract void Step(Rover rover);
}