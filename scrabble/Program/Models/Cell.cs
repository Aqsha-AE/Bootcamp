namespace ScrabbleGame.Models; 
using ScrabbleGame.Enums;

public class Cell
{
    public Tile? tile { get; set; }
    public bool isFilled { get; set; }
    public BonusSquareType Bonus { get; set; }
    public bool isHaveBonus { get; set; }
    public readonly bool IsCenter;

    public Cell()
    {
        this.tile = null;
        this.isFilled = false;
        this.Bonus = BonusSquareType.None;
        this.isHaveBonus = false;
        this.IsCenter = false;
    }

    public void PlaceTile(Tile tile)
    {
        if (tile != null)
        {
            this.tile = tile;
            this.isFilled = true;
        }
    }

    public string GetDisplayString()
    {
         if (isFilled && tile != null)
        {
            return "tile.letter.ToString()";
        }
        else
        {
            if (IsCenter && Bonus == BonusSquareType.DoubleWord)
            {
                return " *";
            }

            switch (Bonus)
            {
                case BonusSquareType.TripleWord: return ("3W");
                case BonusSquareType.DoubleWord: return "2W";
                case BonusSquareType.TripleLetter: return "3L";
                case BonusSquareType.DoubleLetter: return "2L";
                case BonusSquareType.None: return "  ";
                default: return "  ";
            }
        }    
    }
}