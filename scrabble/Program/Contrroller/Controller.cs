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
    private Func<string, bool> _ValidateWord;
    private Action<IPlayer> _TurnChanged;

    public Controller(IBoard board, IDisplay display, List<IPlayer> player, ITileBag tileBag, IDictionary dictionary, Func<string, bool> validateWord, Action<IPlayer> turnChanged)
    {
        _board = board;
        _display = display;
        _player = player;
        _tileBag = tileBag;
        _dictionary = dictionary;
        _ValidateWord = validateWord;
        _TurnChanged = turnChanged;
        _activePlayerIndeks = 0;
        _status = Status.Setup;
    }
    public void StartGame()
    {
        List<Player> newPlayers = new List<Player>();

        _display.DisplayBanner();
        string numPlayersInput = _display.GetInfo("Berapa banyak pemain yang ingin bermain?");
        int numPlayers = int.Parse(numPlayersInput);
        while (numPlayers < 2 || numPlayers > 4)
        {
            _display.SetMessage("Jumlah pemain harus antara 2 dan 4.");
            numPlayersInput = _display.GetInfo("Masukkan jumlah pemain yang valid (2-4):");
            numPlayers = int.Parse(numPlayersInput);
        }

        for (int i = 1; i <= numPlayers; i++)
        {
            string name = _display.GetInfo($"Masukkan nama pemain {i}: ");
            newPlayers.Add(new Player(name));
        }

        _player.AddRange(newPlayers);

        _status = Status.GameStart;
        _display.SetMessage("Permainan dimulai!");
        _display.SetMessage(" ");
    }

    public void ChangeTurn()
    {
        if (_player.Count == 0)
        {
            Console.WriteLine("Tidak ada player yang avalaible untuk changeTurn");
            return;
        }

        this._activePlayerIndeks = (_activePlayerIndeks + 1) % _player.Count;
        System.Console.WriteLine($"ChangeTurn untuk : {_player[_activePlayerIndeks].GetName()}");

        _TurnChanged?.Invoke(_player[_activePlayerIndeks]);
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
                Console.WriteLine($"Tile '{tile.letter}' tidak ada di rak pemain.");
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

        Console.WriteLine($"{player.GetName()} menukar {tiles.Count} ubin.");
    }

    public void passTurn()
    {
        Console.WriteLine($"{_player[_activePlayerIndeks].GetName()} melewati turn.");
        ChangeTurn();
    }

    public bool ChallengeWord(IPlayer challenger)
    {
        System.Console.WriteLine($"{challenger.GetName} meminta untuk challenged the word");
        Console.WriteLine();
        return true;
    }
    public List<Tile> DrawTiles(int count)
    {
        List<Tile> drawnTiles = new List<Tile>();
        Tile tile = _tileBag.GetNextTile();
        if (tile != null)
        {
            drawnTiles.Add(tile);
        }
        return drawnTiles;
    }
    public void Placeword(IPlayer player, Word word)
    {
        List<Position> positions = word.GetFixPosition();

        foreach (var maps in positions)
        {
            //Validasi batas papan
            if (!maps)
            
        }

    }

    public bool ValidateWordPlacement(Word word)
    {
        return true;
    }

    public bool IsValidPlacement(Word word)
    {
        return true;     
    }

    public bool IsCentered(Word word) {
        return true;   
    }

    public bool IsValidWord(string word)
    {
        Dictionary tes = new Dictionary();
        tes.ReadFile("Perpustakaan.txt");
        System.Console.WriteLine("Masukan kata : ");
        string? deInput = Console.ReadLine();
        string de = deInput ?? string.Empty;
        bool isValid = tes.isValidWord(de);
        if (isValid)
        {
            System.Console.WriteLine("validd dah");
        }
        else
        {
            System.Console.WriteLine("salah kata");
        }
        return isValid;
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
    }
}

