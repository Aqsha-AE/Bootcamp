using System;
using System.Collections.Generic;
using System.Linq;
using ScrabbleGame.Interface;

namespace ScrabbleGame.Models
{
    public class TileBag : ITileBag
    {
        private Queue<Tile> _tiles = new Queue<Tile>();

        public TileBag()
        {
            InitializeStandardTiles();
            Shuffle(); 
        }

        public void InitializeStandardTiles()
        {
            _tiles.Clear();
            _tiles = new Queue<Tile>();
            // Membuat daftar tile standar untuk Scrabble
            var tileDistribution = new Dictionary<char, int>
            {
            { 'A', 9 }, { 'B', 2 }, { 'C', 2 }, { 'D', 4 }, { 'E', 12 },
            { 'F', 2 }, { 'G', 3 }, { 'H', 2 }, { 'I', 9 }, { 'J', 1 },
            { 'K', 1 }, { 'L', 4 }, { 'M', 2 }, { 'N', 6 }, { 'O', 8 },
            { 'P', 2 }, { 'Q', 1 }, { 'R', 6 }, { 'S', 4 }, { 'T', 6 },
            { 'U', 4 }, { 'V', 2 }, { 'W', 2 }, { 'X', 1 }, { 'Y', 2 },
            { 'Z', 1 }
            };

            foreach (var tile in tileDistribution)
            {
                for (int i = 0; i < tile.Value; i++)
                {
                    _tiles.Enqueue(new Tile(tile.Key, 1, tile.Key == ' '));
                };
            }

            for (int i = 0; i < 2; i++) {
               _tiles.Enqueue(new Tile(' ', 1, true));
            }
        }

        public Tile GetNextTile()
        {
            if (_tiles.Count == 0)
            {
                throw new InvalidOperationException("TileBag kosong, tidak ada lagi tiles yang bisa diambil.");
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

        public void Shuffle()
        {
            InitializeStandardTiles();
            var Random = new Random();
            var tileList = _tiles.ToList();
            for (int i = tileList.Count - 1; i > 0; i--)
            {
                int j = Random.Next(0, i + 1);
                var temp = tileList[i];
                tileList[i] = tileList[j];
                tileList[j] = temp;
            }

            _tiles = new Queue<Tile>(tileList);
        }
    }
}



        