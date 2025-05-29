namespace ScrabbleGame.Models;
using ScrabbleGame.Enums;

public class Board
{
    const int totalRows = 15;
    const int totalColumns = 15;
    private Cell[,] _grid;
    private Cell _centerCell;

    public Board()
    {
        _grid = new Cell[totalRows, totalColumns];

        for (int i = 0; i < totalRows; i++)
        {
            for (int j = 0; j < totalColumns; j++)
            {
                _grid[i, j] = new Cell();
            }
        }
        _centerCell = _grid[7, 7];
    }

    public Cell GetCell(int x, int y)
    {
        if (x < 0 || x >= totalRows || y < 0 || y >= totalColumns)
        {
            throw new ArgumentOutOfRangeException("Coordinates are out of bounds.");
        }
        return _grid[x, y];
    }

}