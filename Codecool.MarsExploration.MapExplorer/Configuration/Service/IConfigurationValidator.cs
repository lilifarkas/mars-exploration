namespace Codecool.MarsExploration.MapExplorer.Configuration.Service;

public interface IConfigurationValidator
{
    bool Validate(SimulationParameters simulationParameters, MapLoader.MapLoader mapLoader);
}