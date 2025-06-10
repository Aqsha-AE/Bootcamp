namespace ScrabbleGame.GameController;
using ScrabbleGame.Enums;
using ScrabbleGame.Interface;
using ScrabbleGame.Models;
public class Controller
{
    private IBoard _board;
    private IDisplay _display;
    private List<IPlayer> _player;
    private Queue<ITile> _tiles;
    private ITileBag _tileBag;
    private IDictionary _dictionary;
    private int _activePlayerIndeks;
    private Status _status;
    private Action<string> _validateWord;
    private Action<IPlayer> _turnChanged;

    public Controller(IBoard board, IDisplay display, List<IPlayer> player,
                    Queue<ITile> tiles, ITileBag tileBag, IDictionary dictionary,
                    Action<string> validateWord, Action<IPlayer> turnChanged)
    {
        _board = board;
        _display = display;
        _player = player;
        _tileBag = tileBag;
        _tiles = tiles;
        _dictionary = dictionary;
        _validateWord = validateWord;
        _turnChanged = turnChanged;
        _activePlayerIndeks = 0;
        _status = Status.Setup;

    }
    public void StartGame()
    {
        List<IPlayer> newPlayers = new List<IPlayer>();
        _player.AddRange(newPlayers);
        _status = Status.GameStart;
        InitializeTileBag();
        ShuffleTileBag();
        foreach (var player in _player)
        {
            AssignTilesToPlayer(player);
        }
    }
    public IPlayer GetActivePlayer()
    {
        return _player[_activePlayerIndeks];
    }

    public void InitializeTileBag()
    {
        Queue<ITile> tileBag = _tileBag.GetTilebag();
            tileBag.Clear();
            tileBag = new Queue<ITile>();
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
                    tileBag.Enqueue(new Tile(tile.Key, 1, tile.Key == ' '));
                };
            }

            for (int i = 0; i < 2; i++) {
               tileBag.Enqueue(new Tile(' ', 1, true));
            }
            _tileBag.SetTileBag(tileBag);
        }

        public void ShuffleTileBag()
        {
            InitializeTileBag();
            var Random = new Random();
            var tileList = _tileBag.GetTilebag().ToList();
            for (int i = tileList.Count - 1; i > 0; i--)
            {
                int j = Random.Next(0, i + 1);
                var temp = tileList[i];
                tileList[i] = tileList[j];
                tileList[j] = temp;
            }

             _tileBag.SetTileBag(new Queue<ITile>(tileList));
        }
    public List<ITile> DrawTiles(int count)
    {
        List<ITile> drawnTiles = new List<ITile>();
        for (int i = 0; i < count; i++)
        {
            ITile tile = _tileBag.CheckTile();
            if (tile != null)
            {
                drawnTiles.Add(tile);
            }
        }
        return drawnTiles;
    }
    public void AssignTilesToPlayer(IPlayer player)
    {
        List<ITile> newTiles = DrawTiles(7);
        foreach (var tile in newTiles)
        {
            player.AddTile(tile);
        }
    }
    public void SwitchTile(IPlayer player, List<ITile> tiles)
    {
        if (_tileBag.TileSupply() < tiles.Count)
        {
            System.Console.WriteLine("Tiles tidak cukup untuk di tukar.");
            System.Console.WriteLine();
            return;
        }
        foreach (var tile in tiles)
        {
            if (!player.GetTiles().Contains(tile))
            {
                Console.WriteLine($"Tile '{tile.Letter}");
                return;
            }
        }
        foreach (var tile in tiles)
        {
            player.RemoveTile((Tile)tile);
            _tileBag.ReturnTiles((Tile)tile);
        }
        List<Tile> newTiles = this.DrawTiles(tiles.Count).Cast<Tile>().ToList();
        player.GetTiles().AddRange(newTiles);

        Console.WriteLine($"{player.GetName()} menukar {tiles.Count} tile.");
    }
    public void ChangeTurn()
    {
        this._activePlayerIndeks = (_activePlayerIndeks + 1) % this._player.Count;
        _turnChanged?.Invoke(_player[_activePlayerIndeks]);
    }
    public void PlaceWord(IPlayer player, IWord word)
    {
        if (ValidateWordPlacement(word) != validateResult.Success)
        {
            return;
        }

        // Jika ini adalah kata pertama, ubah status permainan
        if (_status == Status.GameStart) _status = Status.GameInProgress;

        int score = ApplyBonus(word);
        List<Position> positions = word.GetFixPosition();
        int tilesPlaced = 0;
        for (int i = 0; i < positions.Count; i++)
        {
            Position pos = positions[i];
            Cell cell = _board.GetCell(pos.x, pos.y);

            if (cell.tile == null)
            {
                ITile testing = word.tiles[i];
                cell.CellTile(testing);
                cell.isFilled = true;
                player.RemoveTile(testing);
                tilesPlaced++;
            }
        }

        int tileTodraw = 7 - player.GetTiles().Count;
        List<Tile> newTiles = DrawTiles(tileTodraw).Cast<Tile>().ToList();
        player.GetTiles().AddRange(newTiles);
        player.AddScore(score);
    }
    public int ApplyBonus(IWord word)
    {
        List<Position> positions = word.GetFixPosition();
        int score = 0;
        int wordMultiplier = 1;
        for (int i = 0; i < word.tiles.Count; i++)
        {
            var pos = positions[i];
            var cell = _board.GetCell(pos.x, pos.y);
            int tileValue = (word?.tiles != null && i >= 0 && i < word.tiles.Count &&
            word.tiles[i] != null)? (word.tiles[i].Value > 0 ? word.tiles[i].Value : 1): 1; 

            if (cell.tile != null) // Tile already exists, do not apply bonus again
            {
                score += tileValue;
                continue;
            }
            switch (cell.Bonus)
            {
                case BonusSquareType.DoubleLetter:
                    score += tileValue * 2;
                    break;
                case BonusSquareType.TripleLetter:
                    score += tileValue * 3;
                    break;
                case BonusSquareType.DoubleWord:
                    wordMultiplier *= 2;
                    score += tileValue;
                    break;
                case BonusSquareType.TripleWord:
                    wordMultiplier *= 3;
                    score += tileValue;
                    break;
                default:
                    score += tileValue;
                    break;
            }
        }
        return score * wordMultiplier;
    }
    public validateResult ValidateWordPlacement(IWord word)
    {
        List<Position> positions = word.GetFixPosition();
        // Validasi dasar
        if (word.tiles == null || positions.Count == 0 || positions.Count != word.tiles.Count)
        {
            return validateResult.InvalidWord;
        }

        // cek apakah posisi horizontal atau vertical
        bool isHorizontal = positions.All(p => p.y == positions[0].y);
        bool isVertical = positions.All(p => p.x == positions[0].x);
        if (!(isHorizontal || isVertical)) return validateResult.NotAligned;

        //cek overlap dengan tile yang sudah ada
        for (int i = 0; i < positions.Count; i++)
        {
            var cell = _board.GetCell(positions[i].x, positions[i].y);
            if (cell.tile != null && word.tiles[i] != null && cell.tile.Letter != word.tiles[i].Letter)
            {
             return validateResult.InvalidOverlap;
            }
        }

        //cek apakah first word sudah ditempatkan
        if (_status == Status.GameStart)
        {
            if (!IsCentered(word))
            {
                return validateResult.FirstWordNotCentered;
            }
        }
        else if (_status == Status.GameInProgress)
        {
            //cek apakah menyambung dengan tile yang sudah ada
            bool connected = false;
            foreach (var pos in positions)
            {
                if ((pos.x > 0 && _board.GetCell(pos.x - 1, pos.y).isFilled) || // Cek kiri
                    (pos.x < 15 - 1 && _board.GetCell(pos.x + 1, pos.y).tile != null) || // Cek kanan
                    (pos.y > 0 && _board.GetCell(pos.x, pos.y - 1).tile != null) || // Cek atas
                    (pos.y < 15 - 1 && _board.GetCell(pos.x, pos.y + 1).tile != null)) // Cek bawah
                {
                    connected = true;
                    break;
                }
            }

            if (!connected)
            {
                return validateResult.NotConnected;
            }
        }
        return validateResult.Success;
    }
    public bool IsCentered(IWord word)
    {    
        return word.GetFixPosition().Any(pos => pos.x == 7 && pos.y == 7);
    }
    public int CalculateWordScore(IWord word)
    {
        int score = 0;
        List<Position> positions = word.GetFixPosition();
        
        for (int i = 0; i < word.tiles.Count; i++)
        {
            score += word.tiles[i].Value;
        }
        return score;
    }
    public int CalculateFinalScore()
    {
        int totalScore = 0;
        foreach (var player in _player)
        {
            if (player.GetScore() < 0)
            {
                player.AddScore(-player.GetScore()); 
            }
            totalScore += player.GetScore();
        }
        return totalScore;
    }
    public bool IsGameOver()
    {
        return _status == Status.GameCompleted;
    }
    public Status GetStatus()
    {
        return _status;
    }
    public void EndGame()
    {
        this._status = Status.GameCompleted;
        Console.WriteLine("Permainan selesai!");
    }

    public List<IPlayer> GetWinner()
    {
        if (_player == null || _player.Count == 0)
            return new List<IPlayer>();

        int maxScore = _player.Max(p => p.GetScore());
       return _player.Where(p => p.GetScore() == maxScore).ToList();
    }
}

