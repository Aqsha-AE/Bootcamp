namespace ScrabbleGame.Models; 
using ScrabbleGame.Enums;
using ScrabbleGame.Interface;


public class Cell
{
    public ITile? tile { get; set; }
    public bool isFilled { get; set; }
    public BonusSquareType Bonus { get; set; }
    public bool isHaveBonus { get; set; }
    public Cell()
    {
        this.tile = null;
        this.isFilled = false;
        this.Bonus = BonusSquareType.None;
        this.isHaveBonus = false;
    }

    public void PlaceTile(ITile tile) 
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

            switch (Bonus)
            {
                case BonusSquareType.TripleWord: return "3W";
                case BonusSquareType.DoubleWord: return "2W";
                case BonusSquareType.TripleLetter: return "3L";
                case BonusSquareType.DoubleLetter: return "2L";
                case BonusSquareType.None: return "  ";
                default: return "  ";
            }
        }
    }
}