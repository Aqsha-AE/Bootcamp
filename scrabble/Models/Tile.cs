using ScrabbleGame.Interface;

namespace ScrabbleGame.Models;

public class Tile :ITile
{
    public char Letter { get; set; }
    public int Value { get; set; }
    public bool isBlanktile { get; set; }

    public Tile(char l, int v, bool blank)
    {
        this.Letter = l;
        this.Value = v;
        this.isBlanktile = blank;
    }

    public override string ToString()
    {
        return $"letter: {Letter}, value: {Value}"; ;
    }
    
}