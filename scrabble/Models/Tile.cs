namespace ScrabbleGame.Models;
using Scrabble.Interfaces;
using Scrabble.Enums;


public class Tile
{
    public char Letter { get; }
    public int Value { get; }
    public bool IsBlanktile { get; }

    public Tile(char l, int Value, bool isBlanktilte = false)
    {
        Letter = l;
        Value = v;
        IsBlanktile = isBlanktile;
    }
}