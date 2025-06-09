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
            ShuffleTileBag(); 
        }

        public void SetTileBag(Queue<ITile> tilebag) {
            _tiles = tilebag;
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

        public void ShuffleTileBag()
        {
            var Random = new Random();
            var tileList = _tiles.ToList();
            for (int i = tileList.Count - 1; i > 0; i--)
            {
                int j = Random.Next(0, i + 1);
                var temp = tileList[i];
                tileList[i] = tileList[j];
                tileList[j] = temp;
            }

            _tiles = new Queue<ITile>(tileList);
        }
    }
}



        