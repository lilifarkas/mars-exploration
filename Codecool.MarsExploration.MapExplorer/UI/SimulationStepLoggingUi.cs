using Codecool.MarsExploration.MapExplorer.Logger;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;

namespace Codecool.MarsExploration.MapExplorer.UI;

public class SimulationStepLoggingUi
{
    private readonly SimulationContext _simulationContext;
    private readonly ILogger _logger;

    public SimulationStepLoggingUi(SimulationContext simulationContext, ILogger logger)
    {
        _simulationContext = simulationContext;
        _logger = logger;
    }

    public void Run()
    {
        _logger.Log($"STEP {_simulationContext.Step}");
        _logger.Log($"EVENT");
        _logger.Log($"UNIT {_simulationContext.Rover.Id}");
        _logger.Log($"POSITION {_simulationContext.Rover.Id}");
    }
}