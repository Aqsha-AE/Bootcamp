using ScrabbleGame.Models;
namespace ScrabbleGame.Interface;

public interface ITileBag
{
    int TileSupply();
    void ShuffleTileBag();
    ITile CheckTile();
    void ReturnTiles(Tile tile);
    void SetTileBag(Queue<ITile> tilebag); 
}