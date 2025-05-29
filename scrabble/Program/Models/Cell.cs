namespace ScrabbleGame.Models;

using ScrabbleGame.Enums;

public class Cell
{
    public Tile? tile { get; set; }
    public bool isFilled => tile != null;
    public BonusSquareType bonus { get; set; }

    public bool isHaveBonus => bonus != BonusSquareType.None;

    public Cell()
    {
        this.bonus = BonusSquareType.None;
    }

    public void PlaceTile(Tile tileToPlace)
    {
        if (isFilled)
        {
            throw new InvalidOperationException("Cell is already filled.");
        }
        if (tileToPlace == null)
        {
            throw new ArgumentNullException(nameof(tileToPlace), "Tile cannot be null.");
        }

        tile = tileToPlace;
    }
}