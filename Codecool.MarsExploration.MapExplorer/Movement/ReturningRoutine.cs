using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;

namespace Codecool.MarsExploration.MapExplorer.Movement;

public class ReturningRoutine : BaseRoutine
{
    private readonly SimulationContext _simulationContext;
    public ReturningRoutine(SimulationContext simulationContext) : base(simulationContext)
    {
        _simulationContext = simulationContext;
    }

    public override void Step(Rover rover)
    {
        Move(rover, _simulationContext.LocationOfTheSpaceship);
        Scan(rover);
    }
}