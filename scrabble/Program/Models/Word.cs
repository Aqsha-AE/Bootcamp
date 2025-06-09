namespace ScrabbleGame.Models;

public class Word
{
    public List<Tile>? tiles { get; private set; }
    public Position? starting { get; private set; }
    public bool isVertical { get; private set; }
    public Word(List<Tile> tiles, Position starting, bool vertical)
    {
        if (tiles == null || tiles.Count == 0)
        {
            System.Console.WriteLine("Gabisa kalau cuman satu Tile");
            return;
        }
        this.tiles = tiles;
        this.starting = starting;
        this.isVertical = vertical;
    }
    public List<Position> GetFixPosition()
    {
        List<Position> positions = new List<Position>();
        if (tiles == null || starting == null)
        {
            return positions;
        }
        for (int i = 0; i < tiles.Count; i++)
        {
            int newX = isVertical ? starting.x : starting.x + i;
            int newY = isVertical ? starting.y + i : starting.y;
            positions.Add(new Position(newX, newY));
        }
        return positions;
    }
}
