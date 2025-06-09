using ScrabbleGame.Interface;

namespace ScrabbleGame.Models;

public class Word : IWord
{
    public string? word { get; }
    public List<ITile>? tiles { get; private set; }
    public Position? starting { get; private set; }
    public bool isVertical { get; private set; }
    public Word(List<ITile> tiles, Position starting, bool vertical)
    {
        if (tiles == null || tiles.Count == 0)
        {
            System.Console.WriteLine("Gabisa kalau cuman satu Tile");
            return;
        }
        this.word = word;
        this.tiles = tiles;
        this.starting = starting;
        this.isVertical = vertical;
    }
    public List<Position> GetFixPosition()
    {
        List<Position> positions = new List<Position>();
        if (tiles == null || starting == null|| tiles.Count == 0)
        {
            Console.WriteLine("Invalid word: tiles or starting position is null");
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
