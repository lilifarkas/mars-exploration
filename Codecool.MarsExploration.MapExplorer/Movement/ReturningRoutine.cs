using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;

namespace Codecool.MarsExploration.MapExplorer.Movement;

public class ReturningRoutine : BaseRoutine
{
    
    private readonly Configuration.Configuration _configuration;
    public ReturningRoutine(CoordinateCalculator coordinateCalculator, Configuration.Configuration configuration) : base(coordinateCalculator)
    {
        _configuration = configuration;
    }

    public override void Step(Rover rover)
    {
        Move(rover, _configuration.LandingSpot);
        Scan(rover);
    }
}