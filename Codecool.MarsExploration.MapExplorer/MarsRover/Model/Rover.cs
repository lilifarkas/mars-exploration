using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public class Rover
{
    public string Id { get; set; }
    public Coordinate CurrentPosition { get; set; }
    public IEnumerable<Coordinate> VisibleTiles { get; set; }
    public IEnumerable<string> EncounteredResources { get; set; }
    
    public Rover(string id, Coordinate currentPosition)
    {
        Id = id;
        CurrentPosition = currentPosition;
    }
}
