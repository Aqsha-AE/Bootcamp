using System;
using System.Collections.Generic;
using System.Linq;
using ScrabbleGame.GameController;
using ScrabbleGame.Interface;

namespace ScrabbleGame.Models
{
    public class TileBag : ITileBag
    {
        private Queue<ITile> _tiles = new Queue<ITile>();

        public TileBag()
        {
            _tiles.Clear();
            _tiles = new Queue<ITile>();
        }

        public void SetTileBag(Queue<ITile> tilebag) {
            _tiles = tilebag;
        }

        public Queue<ITile> GetTilebag()
        {
            return _tiles;
        }
        public ITile CheckTile()
        {
            if (_tiles.Count == 0)
            {
                return null;
            }

            return _tiles.Dequeue();
        }

        public int TileSupply()
        {
            return _tiles.Count;
        }

        public void ReturnTiles(Tile tile)
        {
            _tiles.Enqueue(tile);
        }

    }
}



        