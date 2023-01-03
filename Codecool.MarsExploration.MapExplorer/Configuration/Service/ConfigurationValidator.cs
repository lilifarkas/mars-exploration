using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Configuration.Service;

public class ConfigurationValidator : IConfigurationValidator
{
    public bool Validate(SimulationParameters simulationParameters, MapLoader.MapLoader mapLoader)
    {
        var map = mapLoader.Load(simulationParameters.MapFile);
        if (simulationParameters.StepsToTimeOut > 0 && simulationParameters.SymbolsOfTheResources != null)
        {
            return true;
        }
        throw new NotImplementedException();
    }

    private static bool CoordinateValidator(Map map, Coordinate coordinate)
    {
        throw new NotImplementedException();
    }
}