using Codecool.MarsExploration.MapExplorer.Exploration;
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

    public void Run(SimulationContext simulationContext)
    {
        switch (_simulationContext.ExplorationOutcome)
        {
            case ExplorationOutcome.InProgress:
                _logger.Log($"STEP {_simulationContext.Step} EVENT position UNIT {_simulationContext.Rover.Id} POSITION {_simulationContext.Rover.Id}");
                break;
            case ExplorationOutcome.Colonizable:
                _logger.Log(
                    $"STEP {_simulationContext.Step} EVENT outcome OUTCOME {_simulationContext.ExplorationOutcome}");
                break;
            case ExplorationOutcome.Error:
                _logger.Log($"STEP {_simulationContext.Step} EVENT outcome OUTCOME {_simulationContext.ExplorationOutcome}");
                break;
            case ExplorationOutcome.Timeout:
                _logger.Log($"STEP {_simulationContext.Step} EVENT outcome OUTCOME {_simulationContext.ExplorationOutcome}");
                break;
        }
        
    }
}