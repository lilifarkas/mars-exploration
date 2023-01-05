using Codecool.MarsExploration.MapGenerator.MapElements.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapGenerator.Calculators.Service;

public class CoordinateCalculator : ICoordinateCalculator
{
    private static readonly Random Random = new();

    public Coordinate GetRandomCoordinate(int dimension)
    {
        return new Coordinate(
            Random.Next(dimension),
            Random.Next(dimension)
        );
    }

    public IEnumerable<Coordinate> GetAdjacentCoordinates(Coordinate coordinate, int dimension)
    {
        List<Coordinate> coordinates = new List<Coordinate>();
        //i = 11, i <= 12
        for (int i = coordinate.X -1; i <= coordinate.X+1; i++)
        {
            //j = 11, j <= 12
            for (int j = coordinate.Y-1; j <= coordinate.Y+1; j++)
            {
                // (11 >= 0 true, 11 >= 0 true) && (11 <= 3 true, 0 <= 4 true) && !(1 == 0 && 0 == 0)
                if (j >=0 && i >= 0 && j <= dimension-1 && i <= dimension-1 && !(j == coordinate.Y && i == coordinate.X))
                {
                    coordinates.Add(new Coordinate(i,j));
                }
            }
        }

        return coordinates;
    }

    public IEnumerable<Coordinate> GetAdjacentCoordinates(IEnumerable<Coordinate> coordinates, int dimension)
    {
        return coordinates.SelectMany(c => GetAdjacentCoordinates(c, dimension));
    }
}
