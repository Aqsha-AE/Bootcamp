using ScrabbleGame.Models;
using ScrabbleGame.Enums;
using ScrabbleGame.Interface;
using ScrabbleGame.GameController;

public class Program
{

    public static void Main(string[] args)
    {
        // Initialize the game components
        IDisplay display = new Display();
        IBoard board = new Board();
        ITileBag tileBag = new TileBag();
        IDictionary wordDictionary = new Dictionary();
        List<IPlayer> player = new List<IPlayer>
        {
            new Player("Player 1"),
            new Player("Player 2"),
            new Player("Player 3"),
            new Player("Player 4")
        };
        
        Func<string, bool> validateWord = word => wordDictionary.isValidWord(word);
        Action<IPlayer> turnChanged = p => Console.WriteLine($"It's now {p.GetName()}'s turn.");

        Controller game = new Controller(board, display, player, tileBag, wordDictionary, validateWord, turnChanged);
        game.StartGame(); 

        // Setelah gameController.StartGame();
        foreach (var p in player)
        {
            List<Tile> drawnTiles = game.DrawTiles(7); // Setiap pemain menarik 7 ubin di awal
            p.GetTiles().AddRange(drawnTiles);
            display.SetMessage($"{p.GetName()} menarik {drawnTiles.Count} ubin.");
        }

        // Contoh pertukaran ubin untuk semua pemain (bisa disesuaikan dengan kondisi permainan)
        foreach (var p in player)
        {
            if (p.GetTiles().Count > 0)
            {
                List<Tile> tilesToSwitch = new List<Tile> { p.GetTiles()[0] }; // Misalnya ubin pertama ditukar
                game.SwitchTile(p, tilesToSwitch);
            }
        }
                
        display.DiplayBoard(game);
        /*
        Dictionary tes = new Dictionary();
        tes.ReadFile("Perpustakaan.txt");
        System.Console.WriteLine("Masukan kata : ");
        string de = Console.ReadLine();
        if (tes.isValidWord(de))
        {
            System.Console.WriteLine("validd dah");
        }
        else
        {
            System.Console.WriteLine("salah kata");
        }
        

        //var Board = new Board();
        // Board.DisplayB();


        
                                                                                                                // Contoh menampilkan nama pemain
                                                                                                                Console.WriteLine("Players:");
                                                                                                                foreach (var player in player)
                                                                                                                {
                                                                                                                    Console.WriteLine(player.GetName()); // Pastikan IPlayer punya property Name
                                                                                                                }
                                                                                                        */
    }
}