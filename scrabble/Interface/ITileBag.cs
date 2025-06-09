using ScrabbleGame.Models;
namespace ScrabbleGame.Interface;

public interface ITileBag
{
    int TileSupply();
    void Shuffle();
    Tile GetNextTile();
    void ReturnTiles(Tile tile);
}