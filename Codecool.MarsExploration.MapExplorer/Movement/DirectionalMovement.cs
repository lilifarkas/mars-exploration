using Codecool.MarsExploration.MapExplorer.Direction;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;

namespace Codecool.MarsExploration.MapExplorer.Movement;

public class DirectionalMovement : IDirectionalMovement
{
    private readonly CoordinateCalculator _coordinateCalculator = new CoordinateCalculator();
    private readonly SimulationContext _simulationContext;
    private static readonly Random Random = new();

    public DirectionalMovement(SimulationContext simulationContext)
    {
        _simulationContext = simulationContext;
    }

    private IEnumerable<Coordinate> GetAdjacentEmptyTiles()
    {
        var adjacentCoordinates =
            _coordinateCalculator.GetAdjacentCoordinates(_simulationContext.Rover.CurrentPosition, 9);
        var emptyTiles = new List<Coordinate>();
        var map = _simulationContext.Map;

        foreach (var adjacentCoordinate in adjacentCoordinates)
        {
            if (map.Representation[adjacentCoordinate.X, adjacentCoordinate.Y] == " " && adjacentCoordinate != _simulationContext.Rover.CurrentPosition)
            {
                emptyTiles.Add(adjacentCoordinate);   
            }
        }

        return emptyTiles;
    }

    public void Move()
    {
        throw new NotImplementedException();
    }
    
    private Coordinate MoveLeft(RoverDirection direction, IEnumerable<Coordinate> coordinates)
    {
        throw new NotImplementedException();
    }

    private Coordinate MoveRight(RoverDirection direction, IEnumerable<Coordinate> coordinates)
    {
        throw new NotImplementedException();
    }

    private Coordinate MoveDown(RoverDirection direction, IEnumerable<Coordinate> coordinates)
    {
        throw new NotImplementedException();
    }

    private Coordinate MoveUp(RoverDirection direction, IEnumerable<Coordinate> coordinates)
    {
        throw new NotImplementedException();
    }
}