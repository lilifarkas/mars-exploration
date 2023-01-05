using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;

namespace Codecool.MarsExploration.MapExplorer.Movement;

public abstract class BaseRoutine
{
    private readonly CoordinateCalculator _coordinateCalculator = new CoordinateCalculator();
    
    private readonly SimulationContext _simulationContext;

    protected BaseRoutine(SimulationContext simulationContext)
    {
        _simulationContext = simulationContext;
    }
    
    protected void Move(Rover rover,Coordinate coordinate)
    {
        rover.CurrentPosition = coordinate;
    }

    protected void Scan(Rover rover)
    {
        rover.VisibleTiles = _coordinateCalculator.GetAdjacentCoordinates(rover.CurrentPosition, 31);
        
        var map = _simulationContext.Map;
        
        var resources = rover.EncounteredResources.ToList();
        
        foreach (var visibleTile in rover.VisibleTiles)
        {
            if (_simulationContext.SymbolsToLookFor.Contains(map.Representation[visibleTile.X,visibleTile.Y]))
            {
                resources.Add(visibleTile);
            }
        }

        rover.EncounteredResources = resources;
    }

    public abstract void Step(Rover rover);
}