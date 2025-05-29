namespace ScrabbleGame.Models;
using ScrabbleGame.Enums;

public class Word
{
    public List<Tile> tiles { get; set; }
    public Position starting { get; set; }
    public bool isVertical { get; set; }

    public Word(List<Tile> tiles, Position starting, bool vertical)
    {
        this.tiles = tiles ?? new List<Tile>();
        this.starting = starting;
        this.isVertical = vertical;
    }
    public List<Position> GetFixPositions()
    {
        List<Position> fixPositions = new List<Position>();
        if (tiles == null || tiles.Count == 0)
        {
            return fixPositions;
        }

        for (int i = 0; i < tiles.Count; i++)
        {
            // Use 'x' and 'y' directly from your Position class
            int currentX = starting.x + (isVertical ? i : 0);
            int currentY = starting.y + (isVertical ? 0 : i);
            fixPositions.Add(new Position(currentX, currentY));
        }
        return fixPositions;
    }
}