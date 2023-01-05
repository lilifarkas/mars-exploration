using Codecool.MarsExploration.MapExplorer.Direction;
using Codecool.MarsExploration.MapExplorer.MarsRover;
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
            _coordinateCalculator.GetAdjacentCoordinates(_simulationContext.Rover.CurrentPosition, _simulationContext.Map.Representation.Length);
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
        var coords = GetAdjacentEmptyTiles();
        var acceptedCoords = new List<Coordinate>();
 
        var roverDirection = _simulationContext.Rover.Direction;
        acceptedCoords = roverDirection switch
        {
            RoverDirection.Left => (List<Coordinate>)MoveLeft(coords),
            RoverDirection.Right => (List<Coordinate>)MoveRight(coords),
            RoverDirection.Up => (List<Coordinate>)MoveUp(coords),
            RoverDirection.Down => (List<Coordinate>)MoveDown(coords),
            _ => acceptedCoords
        };
        _simulationContext.Rover.CurrentPosition = acceptedCoords[Random.Next(acceptedCoords.Count)];
    }
    
    private IEnumerable<Coordinate> MoveLeft(IEnumerable<Coordinate> coordinates)
    {
        var currentPos = _simulationContext.Rover.CurrentPosition;
        List<Coordinate> acceptedCoordinates = new List<Coordinate>();
        foreach (var coordinate in coordinates)
        {
            if (coordinate.Y - currentPos.Y <= 0)
            {
                acceptedCoordinates.Add(coordinate);
            }
        }

        return acceptedCoordinates;
    }

    private IEnumerable<Coordinate> MoveRight(IEnumerable<Coordinate> coordinates)
    {
        var currentPos = _simulationContext.Rover.CurrentPosition;
        List<Coordinate> acceptedCoordinates = new List<Coordinate>();
        foreach (var coordinate in coordinates)
        {
            if (coordinate.Y - currentPos.Y >= 0)
            {
                acceptedCoordinates.Add(coordinate);
            }
        }

        return acceptedCoordinates;
    }

    private IEnumerable<Coordinate> MoveDown(IEnumerable<Coordinate> coordinates)
    {
        var currentPos = _simulationContext.Rover.CurrentPosition;
        List<Coordinate> acceptedCoordinates = new List<Coordinate>();
        foreach (var coordinate in coordinates)
        {
            if (coordinate.X - currentPos.X >= 0)
            {
                acceptedCoordinates.Add(coordinate);
            }
        }

        return acceptedCoordinates;
    }

    private IEnumerable<Coordinate> MoveUp(IEnumerable<Coordinate> coordinates)
    {
        var currentPos = _simulationContext.Rover.CurrentPosition;
        List<Coordinate> acceptedCoordinates = new List<Coordinate>();
        foreach (var coordinate in coordinates)
        {
            if (coordinate.X - currentPos.X <= 0)
            {
                acceptedCoordinates.Add(coordinate);
            }
        }

        return acceptedCoordinates;
    }
}