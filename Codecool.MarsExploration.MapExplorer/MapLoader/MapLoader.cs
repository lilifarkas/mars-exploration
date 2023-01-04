
using Codecool.MarsExploration.MapGenerator.MapElements.Model;


namespace Codecool.MarsExploration.MapExplorer.MapLoader;

public class MapLoader : IMapLoader
{
    public Map Load(string mapFile)
    {

        var fileData = File.ReadAllLines(mapFile);
        var mapRepresentation = CreateMapRepresentation(fileData);

        return new Map(mapRepresentation, true);
    }
    
    private static string[,] CreateMapRepresentation(string[] fileText)
    {
        string[,] mapRepresentation = new string[fileText.Length,fileText.Length];

        int row = 0;
        foreach (var s in fileText)
        {
            for (var i = 0; i < s.Length; i++)
            {
                mapRepresentation[row, i] = s[i].ToString();
            }
            
            row++;
        }
        return mapRepresentation;

    }
}