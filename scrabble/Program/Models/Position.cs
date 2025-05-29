namespace ScrabbleGame.Models; 
using ScrabbleGame.Enums;
public class Position
{
    public int x { get; }
    public int y { get; }
    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public bool isValid (bool isHorizontal, int length, int totalRows, int totalColumns)
    {
        if (isHorizontal)
        {
            return x >= 0 && x < totalRows && y >= 0 && y + length - 1 < totalColumns;
        }
        else
        {
            return x >= 0 && x + length - 1 < totalRows && y >= 0 && y < totalColumns;
        }
    }
}