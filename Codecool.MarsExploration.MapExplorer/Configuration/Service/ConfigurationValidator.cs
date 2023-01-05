using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Configuration.Service;

public class ConfigurationValidator : IConfigurationValidator
{
    private readonly ICoordinateCalculator _coordinateCalculator = new CoordinateCalculator();
    public bool LandingSpotValidate(Map map, Coordinate landingCoordinates)
    {
        return map.Representation[landingCoordinates.X, landingCoordinates.Y] == " " &&
               _coordinateCalculator.GetAdjacentCoordinates(landingCoordinates, 3).Any(coord => map.Representation[coord.X,coord.Y] == " ");
    }

    public bool MapFileValidate(string mapFile)
    {
        return mapFile.Length > 1;
    }

    public bool ResourcesValidate(IEnumerable<string> symbolsOfTheResources)
    {
        var symbols = new List<string> { "#", "%", "*", "&" };
        return symbols.Any(symbol=>symbolsOfTheResources.Any(resourceSymbol => resourceSymbol == symbol));
    }

    public bool StepsToTimeoutValidate(int stepsToTimeout)
    {
        return stepsToTimeout > 0;
    }
}