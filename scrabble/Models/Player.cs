using System.Collections.Generic;
using ScrabbleGame.Interface;
namespace ScrabbleGame.Models;

public class Player : IPlayer
{
    private string _name;
    private List<Tile> _tiles;
    private int _score;

    public Player(string name)
    {
        _name = name;
        _tiles = new List<Tile>();
        _score = 0;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetScore()
    {
        return _score;
    }

    public void AddScore(int score)
    {
        _score += score;
    }
    public void Tiles(List<Tile> tiles)
    {
        _tiles = tiles;
    }

    public List<Tile> GetTiles() => _tiles;
    public void AddTile(Tile tile) => _tiles.Add(tile);
    public bool RemoveTile(Tile tile)
{     Tile? tileToRemove = _tiles.FirstOrDefault(t => 
            t.letter == tile.letter
            && t.value == tile.value);

        if (tileToRemove != null)
        {
            return _tiles.Remove(tileToRemove); 
        }
        return false;}

    public void ShuffleTiles()
    {
        var random = new Random();
        _tiles = _tiles.OrderBy(t => random.Next()).ToList();
        Console.WriteLine($"{GetName()}'s Tile sudah di acak: {string.Join(" ", _tiles.Select(t => t.letter))}");
    }
    
}