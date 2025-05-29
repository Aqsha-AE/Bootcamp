namespace Scrabble;
using Scrabble.Interfaces;
using Scrabble.Enums;

public class Cell
{
    public Tile Tile { get; set; }
    public bool IsFilled => Tile != null;
    public BonusSquareType Bonus { get; }
    public bool IsHaveBonus => Bonus != BonusSquareType.None;
    public Cell()
    {
        Tile = null;
        Bonus = BonusSquareType.None;
    }

    public PlaceTile(Tile tiletoPlace)
    {
        if (IsFilled)
        {
            throw new InvalidOperationException("Cell is already filled.");
        }
        if (tiletoPlace == null)
        {
            throw new ArgumentNullException(nameof(tiletoPlace), "Tile cannot be null.");
        }

        Tile = tiletoPlace;
    }

    public void RemoveTile()
    {
        Tile = null;
    }

    public override string ToString()
    {
        if (IsFilled)
        {
            string BonusString = isHaveBonus ? $" (Bonus: {Bonus})" : string.Empty;
            return $"{Tile.Letter}{BonusString}";
        }

        else
        {
            switch (Bonus)
            {
                case BonusSquareType.DoubleLetter:
                    return "[DL]";
                case BonusSquareType.TripleLetter:
                    return "[TL]";
                case BonusSquareType.DoubleWord:
                    return "[DW]";
                case BonusSquareType.TripleWord:
                    return "[TW]";
                default:
                    return "[ ]"; // No bonus
            }
        }
     }
}