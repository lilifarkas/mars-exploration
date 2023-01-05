using Codecool.MarsExploration.MapExplorer.Direction;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public class Rover
{
    public string Id { get; set; }
    public Coordinate CurrentPosition { get; set; }
    public IEnumerable<Coordinate> VisibleTiles { get; set; }
    public IEnumerable<Coordinate> EncounteredResources { get; set; }
    public RoverDirection Direction { get; set; }
    
    public Rover(string id, Coordinate currentPosition, IEnumerable<Coordinate> visibleTiles, IEnumerable<Coordinate> encounteredResources, RoverDirection direction)
    {
        Id = id;
        CurrentPosition = currentPosition;
        VisibleTiles = visibleTiles;
        EncounteredResources = encounteredResources;
        Direction = direction;
    }
}
