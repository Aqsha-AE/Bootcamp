using ScrabbleGame.Models;
namespace ScrabbleGame.Interface;

public interface ITileBag
{
    int TileSupply();
    void ShuffleTileBag();
    Tile CheckTile();
    void ReturnTiles(Tile tile);
}