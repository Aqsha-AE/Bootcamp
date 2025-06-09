namespace ScrabbleGame.Models;

public class Tile
{
    public char letter { get; set; }
    public int value { get; set; }
    public bool isBlanktile { get; set; }

    public Tile(char l, int v, bool blank)
    {
        this.letter = l;
        this.value = v;
        this.isBlanktile = blank;
    }

    public override string ToString()
    {
        return $"letter: {letter}, value: {value}"; ;
    }
    
}