namespace ScrabbleGame.Models; 

public class Position
{
    public int x;
    public int y;

    public Position (int x, int y)
    {
        this.x = x; 
        this.y = y; 
    }

    public bool isValid()
    {
        const int boardSize = 15; 

        return x >= 0 && x < boardSize &&
               y >= 0 && y < boardSize; 
    }
}