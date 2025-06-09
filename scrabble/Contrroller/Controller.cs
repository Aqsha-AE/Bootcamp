namespace ScrabbleGame.GameController;
using ScrabbleGame.Enums;
using ScrabbleGame.Interface;
using ScrabbleGame.Models;
public class Controller
{
    private IBoard _board;
    private IDisplay _display;
    private List<IPlayer> _player;
    private ITileBag _tileBag;
    private IDictionary _dictionary;
    private int _activePlayerIndeks;
    private Status _status;
    private Action<string> _validateWord;
    private Action<IPlayer> _turnChanged;

    public Controller(IBoard board, IDisplay display, List<IPlayer> player, ITileBag tileBag, IDictionary dictionary, Action<string> validateWord, Action<IPlayer> turnChanged)
    {
        _board = board;
        _display = display;
        _player = player;
        _tileBag = tileBag;
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
    }
    public IPlayer GetActivePlayer()
    {
        return _player[_activePlayerIndeks];
    }
    public List<Tile> DrawTiles(int count)
    {
        List<Tile> drawnTiles = new List<Tile>();
        for (int i = 0; i < count; i++) 
        {
            Tile tile = _tileBag.CheckTile();
            if (tile != null)
            {
                drawnTiles.Add(tile);
            }
        }
        return drawnTiles;
    }
    public void AssignTilesToPlayer(IPlayer player)
    {
        List<Tile> newTiles = DrawTiles(7);
        foreach (var tile in newTiles)
        {
            player.AddTile(tile);
        }
    }
    public void SwitchTile(IPlayer player, List<Tile> tiles)
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
                Console.WriteLine($"Tile '{tile.letter}");
                return;
            }
        }
        foreach (var tile in tiles)
        {
            player.RemoveTile(tile);
            _tileBag.ReturnTiles(tile);
        }
        List<Tile> newTiles = this.DrawTiles(tiles.Count);
        player.GetTiles().AddRange(newTiles);

        Console.WriteLine($"{player.GetName()} menukar {tiles.Count} tile.");
    }
    public void ChangeTurn()
    {
        if (_player.Count == 0)
        {
            Console.WriteLine("Tidak ada player yang avalaible untuk changeTurn");
            return;
        }

        this._activePlayerIndeks = (_activePlayerIndeks + 1) % this._player.Count;
        System.Console.WriteLine($"ChangeTurn untuk : {_player[_activePlayerIndeks].GetName()}");

        _turnChanged?.Invoke(_player[_activePlayerIndeks]);
    }
    public void PlaceWord(IPlayer player, IWord word)
    {
        if (!ValidateWordPlacement(word))
        {
            Console.WriteLine("Invalid word placement.");
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
                Tile testing = word.tiles[i];
                cell.PlaceTile(testing);
                cell.isFilled = true;
                player.RemoveTile(testing);
                tilesPlaced++; 
            }
        }

        int tileTodraw = 7 - player.GetTiles().Count;
        List<Tile> newTiles = DrawTiles(tileTodraw);
        player.GetTiles().AddRange(newTiles);
        player.AddScore(score);
        Console.WriteLine($"{player.GetName()} mendapatkan skor {score}.");
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
            word.tiles[i] != null)? (word.tiles[i].value > 0 ? word.tiles[i].value : 1): 1; 

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
    public bool ValidateWordPlacement(IWord word)
    {
        List<Position> positions = word.GetFixPosition();
        // Validasi dasar
        if (word.tiles == null || positions.Count == 0 || positions.Count != word.tiles.Count)
        {
            Console.WriteLine("Invalid word: no tiles or invalid positions");
            return false;
        }

        // cek apakah posisi horizontal atau vertical
        bool isHorizontal = positions.All(p => p.y == positions[0].y);
        bool isVertical = positions.All(p => p.x == positions[0].x);
        if (!(isHorizontal || isVertical)) return false;

        //cek overlap dengan tile yang sudah ada
        for (int i = 0; i < positions.Count; i++)
        {
            var cell = _board.GetCell(positions[i].x, positions[i].y);
            if (cell.tile != null && word.tiles[i] != null && cell.tile.letter != word.tiles[i].letter)
            {
                Console.WriteLine("Invalid placement. The word overlaps with existing tiles in an invalid way.");
                return false;
            }
        }

        //cek apakah first word sudah ditempatkan
        if (_status == Status.GameStart)
        {
            if (!IsCentered(word))
            {
                Console.WriteLine("First word must be placed in the center of the board.");
                return false;
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
                Console.WriteLine("Kata harus terhubung dengan kata yang sudah ada di board.");
                return false;
            }
        }
        return true;
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
            score += word.tiles[i].value;
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
    public void DisplayB()
    {
        _board.DisplayB();
    }

    public void EndGame()
    {
        this._status = Status.GameCompleted;
        Console.WriteLine("Permainan selesai!");
    }

    public (IPlayer? Winner, GameResult Result) Winner()
    {
        if (_player == null || _player.Count == 0)
            return (null, GameResult.NoWinner);

        int maxScore = _player.Max(p => p.GetScore());
        var winners = _player.Where(p => p.GetScore() == maxScore).ToList();

        if (winners.Count == 1)
            return (winners[0], GameResult.WinnerFound);
        else
            return (null, GameResult.NoWinner);
    }
}

