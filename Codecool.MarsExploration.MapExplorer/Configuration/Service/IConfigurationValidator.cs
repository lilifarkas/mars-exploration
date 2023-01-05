using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Configuration.Service;

public interface IConfigurationValidator
{
    bool LandingSpotValidate(Map map, Coordinate landingCoordinates);
    bool MapFileValidate(string mapFile);
    bool ResourcesValidate(IEnumerable<string> symbolsOfTheResources);
    bool StepsToTimeoutValidate(int stepsToTimeout);
}