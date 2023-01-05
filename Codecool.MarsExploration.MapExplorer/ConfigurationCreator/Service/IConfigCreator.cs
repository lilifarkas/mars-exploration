using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.ConfigurationCreator.Service;

public interface IConfigCreator
{
    public Configuration.Configuration ConfigurationCreator(string mapFile, List<string> resources,
        Coordinate landingCoordinate, int stepsToTimeout);
}