using Codecool.MarsExploration.MapExplorer.Configuration.Service;
using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.ConfigurationCreator.Service;

public class ConfigCreator : IConfigCreator
{
    private static IConfigurationValidator _configurationValidator;
    private static IMapLoader _mapLoader;
    private static readonly Random Random = new Random();
    
    public ConfigCreator(IConfigurationValidator configurationValidator, IMapLoader mapLoader)
    {
        _configurationValidator = configurationValidator;
        _mapLoader = mapLoader;
    }

    public Configuration.Configuration ConfigurationCreator(string mapFile, List<string> resources, Coordinate landingCoordinate, int stepsToTimeout)
    {
        return new Configuration.Configuration(mapFile, FindLandingSpot(_mapLoader.Load(mapFile), landingCoordinate),
            resources, stepsToTimeout);
    }

    private static Coordinate FindLandingSpot(Map map, Coordinate landingCoordinate)
    {
        while (!_configurationValidator.LandingSpotValidate(map,landingCoordinate))
        {
            landingCoordinate = new Coordinate(Random.Next(map.Representation.GetLength(0)),
                Random.Next(map.Representation.GetLength(0)));
        }

        return landingCoordinate;
    }
    
}