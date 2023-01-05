using Codecool.MarsExploration.MapExplorer.Configuration.Service;
using Codecool.MarsExploration.MapExplorer.ConfigurationCreator.Service;
using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer;

class Program
{
    private static readonly string WorkDir = AppDomain.CurrentDomain.BaseDirectory;

    public static void Main(string[] args)
    {
        IConfigurationValidator configurationValidator = new ConfigurationValidator();
        IMapLoader mapLoader = new MapLoader.MapLoader();
        IConfigCreator configCreator = new ConfigCreator(configurationValidator, mapLoader);
        
        var mapFile = $@"{WorkDir}\Resources\exploration-0.map";
        var resources = new List<string>() { "*", "%" };
        const int stepsToTimeout = 90;
        var landingSpot = new Coordinate(6, 6);

        var configObject = configCreator.ConfigurationCreator(mapFile, resources, landingSpot, stepsToTimeout);

    }
}
