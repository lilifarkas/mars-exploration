using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Configuration.Service;

public class ConfigurationValidator : IConfigurationValidator
{
    public bool Validate(Configuration configuration, MapLoader.MapLoader mapLoader)
    {
        var map = mapLoader.Load(configuration.MapFile);
        if (CoordinateValidator(map.Representation, configuration.LandingSpot) 
            && configuration.StepsToTimeOut > 0
            && configuration.SymbolsOfTheResources != null)
        {
            return true;
        }

        return false;
    }

    private static bool CoordinateValidator(string?[,] map, Coordinate coordinate)
    {
        var allXCoordinates =
            Enumerable.Range(coordinate.X, 1)
                .Select(e => coordinate with { X = e });

        var allYCoordinates =
            Enumerable.Range(coordinate.Y, 1)
                .Select(e => coordinate with { Y = e });
        
        return coordinate.X >= 0
               && coordinate.X < map.GetLength(0)
               && coordinate.Y >= 0
               && coordinate.Y < map.GetLength(1)
               && map[coordinate.X, coordinate.Y] == null
               && allXCoordinates.Concat(allYCoordinates).All(c => map[c.X, c.Y] == null);
    }
}