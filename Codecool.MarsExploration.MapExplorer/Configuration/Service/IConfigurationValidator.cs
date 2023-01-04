namespace Codecool.MarsExploration.MapExplorer.Configuration.Service;

public interface IConfigurationValidator
{
    bool Validate(Configuration configuration, MapLoader.MapLoader mapLoader);
}