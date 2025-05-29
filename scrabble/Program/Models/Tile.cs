namespace ScrabbleGame.Models;
using ScrabbleGame.Enums;

public class Tile
{
    public char letter { get; }
    public int value { get; }
    public bool isBlanktile { get; }

    public Tile(char l, int v, bool isBlanktilte = false)
    {
        letter = l;
        value = v;
        isBlanktile = isBlanktile;
    }
}