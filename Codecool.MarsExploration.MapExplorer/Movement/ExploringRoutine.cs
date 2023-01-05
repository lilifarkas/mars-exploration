using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;

namespace Codecool.MarsExploration.MapExplorer.Movement;

public class ExploringRoutine : BaseRoutine
{
    public ExploringRoutine(CoordinateCalculator coordinateCalculator) : base(coordinateCalculator)
    {
    }

    public override void Run(Rover rover)
    {
        throw new NotImplementedException();
    }
}