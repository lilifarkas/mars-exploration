using Codecool.MarsExploration.MapExplorer.Analyzer;
using Codecool.MarsExploration.MapExplorer.Configuration.Service;
using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapExplorer.MarsRover.Service;
using Codecool.MarsExploration.MapExplorer.Movement;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.Service;

public class ExplorationSimulator : IExplorationSimulator
{
    private readonly IMapLoader _mapLoader;
    private  readonly Random Random = new Random();
    private  IConfigurationValidator _configurationValidator;
    private  IOutcomeAnalyzer _lackOfResourcesAnalyzer;
    private  IOutcomeAnalyzer _succesAnalyzer;
    private  IOutcomeAnalyzer _timeOutanalyzer;
    private IRoverDeployer _roverDeployer;

    public ExplorationSimulator(IMapLoader mapLoader, IConfigurationValidator configurationValidator, IOutcomeAnalyzer lackOfResourcesAnalyzer, IOutcomeAnalyzer succesAnalyzer, IOutcomeAnalyzer timeOutanalyzer, IRoverDeployer roverDeployer)
    {
        _mapLoader = mapLoader;
        _configurationValidator = configurationValidator;
        _lackOfResourcesAnalyzer = lackOfResourcesAnalyzer;
        _succesAnalyzer = succesAnalyzer;
        _timeOutanalyzer = timeOutanalyzer;
        _roverDeployer = roverDeployer;
    }

    public void RunSimulation(Configuration.Configuration configuration)
    {
        var map = _mapLoader.Load(configuration.MapFile);
        //var landingSpot = CheckLandingSpotForClear(configuration.LandingSpot, map);
        var rover = _roverDeployer.Deploy();
        var simulationContext = new SimulationContext(0, configuration.StepsToTimeOut, rover,
            configuration.LandingSpot, map, configuration.SymbolsOfTheResources);
        ExploringRoutine exploringRoutine = new ExploringRoutine(simulationContext);
        
        var finishedSimulationContext = SimulationLoop(simulationContext, exploringRoutine);
    }

    public SimulationContext HandleOutcome(SimulationContext simulationContext, ExplorationOutcome outcome)
    {
        return simulationContext with { ExplorationOutcome = outcome };
    }

    private SimulationContext SimulationLoop(SimulationContext simulationContext, ExploringRoutine exploringRoutine)
    {
        int step = 1;
        while (simulationContext.ExplorationOutcome == ExplorationOutcome.InProgress && simulationContext.StepsToReachTimeOut > step)
        {
            var message = $"STEP: {step}, POSITION: {simulationContext.Rover.CurrentPosition}";
            Console.WriteLine(message);
            exploringRoutine.Step(simulationContext.Rover);
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
            Console.WriteLine("asd");
            landingCoordinate = new Coordinate(Random.Next(map.Representation.GetLength(0)),
                Random.Next(map.Representation.GetLength(0)));
        }

        return landingCoordinate;
    }
}