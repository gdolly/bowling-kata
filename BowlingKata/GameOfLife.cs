namespace BowlingKata;

public class GameOfLife
{
    private readonly int _length;
    private readonly int _breadth;
    private readonly List<List<bool>> _grid = [];
    private const string Live = "*";
    private const string Dead = ".";

    public GameOfLife(int length, int breadth, List<Tuple<int, int>>? livePopulation = null)
    {
        _length = length;
        _breadth = breadth;
        InitializeGrid(length, breadth, livePopulation);
    }

    private void InitializeGrid(int length, int breadth, List<Tuple<int, int>>? livePopulation)
    {
        for (var i = 0; i < length; i++)
        {
            _grid.Add([]);
            for (var j = 0; j < breadth; j++)
            {
                if (livePopulation?.Contains(new Tuple<int, int>(i, j)) ?? false)
                {
                    _grid[i].Add(true);
                }
                else _grid[i].Add(false);
            }
        }
    }

    public string Show()
    {
        var gridString = "";
        for (var i = 0; i < _length; i++)
        {
            for (var j = 0; j < _breadth; j++)
            {
                if (_grid[i][j]) gridString += Live;
                else gridString += Dead;
            }
            gridString += "\n";
        }

        return gridString.Trim();
    }

    public void NextGeneration()
    {
        for (var i = 0; i < _length; i++)
        {
            for (var j = 0; j < _breadth; j++)
            {
                if (IsAlive(i, j))
                {
                    var allNeighbours = new List<Tuple<int, int>>()
                    {
                        new(i+1, j),new(i-1, j), new(i, j+1), new(i, j-1), new(i+1, j+1), new(i+1, j-1), new(i-1, j+1), new(i-1, j-1)
                    };
                    var liveNeighbours = allNeighbours.Count(n => IsAlive(n.Item1, n.Item2));
                    if (liveNeighbours < 2)
                    {
                        _grid[i][j] = false;
                    }
                }
            }
        }
    }

    private bool IsAlive(int i, int j)
    {
        return _grid[i][j];
    }
}