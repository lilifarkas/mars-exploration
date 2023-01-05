using Codecool.MarsExploration.MapExplorer.Analyzer;
using Codecool.MarsExploration.MapExplorer.Configuration.Service;
using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapExplorer.Movement;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.Service;

public class ExplorationSimulator : IExplorationSimulator
{
    private readonly Rover _rover;
    private readonly IMapLoader _mapLoader;
    private  readonly Random Random = new Random();
    private  IConfigurationValidator _configurationValidator;
    private  IOutcomeAnalyzer _lackOfResourcesAnalyzer;
    private  IOutcomeAnalyzer _succesAnalyzer;
    private  IOutcomeAnalyzer _timeOutanalyzer;
    private  ExploringRoutine _exploringRoutine;
    private  ReturningRoutine _returningRoutine;

    public ExplorationSimulator(Rover rover, IMapLoader mapLoader, IConfigurationValidator configurationValidator,ExploringRoutine exploringRoutine, ReturningRoutine returningRoutine, IOutcomeAnalyzer lackOfResourcesAnalyzer, IOutcomeAnalyzer succesAnalyzer, IOutcomeAnalyzer timeOutanalyzer)
    {
        _rover = rover;
        _mapLoader = mapLoader;
        _configurationValidator = configurationValidator;
        _exploringRoutine = exploringRoutine;
        _returningRoutine = returningRoutine;
        _lackOfResourcesAnalyzer = lackOfResourcesAnalyzer;
        _succesAnalyzer = succesAnalyzer;
        _timeOutanalyzer = timeOutanalyzer;
    }

    public void RunSimulation(Configuration.Configuration configuration)
    {
        var map = _mapLoader.Load(configuration.MapFile);
        var landingSpot = CheckLandingSpotForClear(configuration.LandingSpot, map);
        var simulationContext = new SimulationContext(0, configuration.StepsToTimeOut, _rover,
            landingSpot, map, configuration.SymbolsOfTheResources);
        
    }

    public SimulationContext HandleOutcome(SimulationContext simulationContext, ExplorationOutcome outcome)
    {
        return simulationContext with { ExplorationOutcome = outcome };
    }

    private SimulationContext SimulationLoop(SimulationContext simulationContext)
    {
        int step = 1;
        while (simulationContext.ExplorationOutcome == ExplorationOutcome.InProgress)
        {
            var message = $"STEP: {step}, POSITION: {simulationContext.Rover.CurrentPosition}";
            Console.WriteLine(message);
            _exploringRoutine.Step(simulationContext.Rover);
            var results = new[] {
                _lackOfResourcesAnalyzer.Analyze(simulationContext), _succesAnalyzer.Analyze(simulationContext),
                _timeOutanalyzer.Analyze(simulationContext)
            };
            if (results.Any(s=> s != ExplorationOutcome.InProgress))
            {
                var outcome = results.Single(s => s != ExplorationOutcome.InProgress);
                simulationContext = HandleOutcome(simulationContext, outcome);
            }
            step++;
        }
        return simulationContext with { Step = step };
    }
    private Coordinate CheckLandingSpotForClear(Coordinate landingCoordinate, Map map)
    {
        while (!_configurationValidator.LandingSpotValidate(map,landingCoordinate))
        {
            landingCoordinate = new Coordinate(Random.Next(map.Representation.GetLength(0)),
                Random.Next(map.Representation.GetLength(0)));
        }

        return landingCoordinate;
    }
}