using ScrabbleGame.Models;

namespace ScrabbleGame.Interface;

public interface IPlayer
{
    string GetName();
    int GetScore();
    void AddScore(int score);
    void Tiles(List<ITile> tiles);
    List<ITile> GetTiles();
    void AddTile(ITile tile);
    bool RemoveTile(ITile tile);
    void ShuffleTiles();
    
    
}