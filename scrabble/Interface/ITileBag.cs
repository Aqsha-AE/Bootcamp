using ScrabbleGame.Models;
namespace ScrabbleGame.Interface;

public interface ITileBag
{
    int TileSupply();
    ITile CheckTile();
    void ReturnTiles(Tile tile);
    void SetTileBag(Queue<ITile> tilebag);

    public Queue<ITile> GetTilebag();
}