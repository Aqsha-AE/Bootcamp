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
        List<IPlayer> player = new List<IPlayer>();

        Func<string, bool> validateWord = word => wordDictionary.isValidWord(word);
        Action<IPlayer> turnChanged = p => Console.WriteLine($"It's now {p.GetName()}'s turn.");

        Controller game = new Controller(board, display, player, tileBag, wordDictionary, validateWord, turnChanged);
        game.StartGame();

        // Main game loop
        while (game.GetStatus() == Status.GameStart)
        {
            display.DiplayBoard(game);
            System.Console.WriteLine();

            // Show each player's tiles at the start of the turn
            foreach (var p in player)
            {
                display.SetMessage($"{p.GetName()} tiles: " + string.Join(", ", p.GetTiles().Select(t => t.letter)));
            }

            display.SetMessage("Choose an action:");
            display.SetMessage("1. Place a word");
            display.SetMessage("2. Pass Turn");
            display.SetMessage("3. Shuffle Rack");
            display.SetMessage("4. Switch Tiles");
            display.SetMessage("5. End Game");

            // Read user input and process action
            string input = Console.ReadLine();
            if (input == "5")
            {
                display.SetMessage("Game ended by user.");
                break; // Exit the loop
            }

            // TODO: Implement other actions based on input
        }
    }
}