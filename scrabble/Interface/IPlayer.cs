using ScrabbleGame.Models;

namespace ScrabbleGame.Interface;

public interface IPlayer
{
    string GetName();
    int GetScore();
    void AddScore(int score);
    void Tiles(List<Tile> tiles);
    List<Tile> GetTiles();
    void AddTile(Tile tile);
    bool RemoveTile(Tile tile);
    void ShuffleTiles();
    
    
}