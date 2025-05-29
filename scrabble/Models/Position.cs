namespace ScrabbleGame.Models;
using Scrabble.Interfaces;
using Scrabble.Enums;

public class Position
{
    public int x { get; }
    public int y { get; }

    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public isValid(bool isHorizontal, int length)
    {
        const int BoardSize = 15
        return x >= 0 && x < BoardSize &&
               y >= 0 && y < BoardSize &&;
    }
    
    public override string ToString()
    {
        return $"({x}, {y})";
    }
}