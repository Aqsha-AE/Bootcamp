using ScrabbleGame.Models;
using ScrabbleGame.Enums;
using ScrabbleGame.Interface;
using ScrabbleGame.GameController;

public class Program
{

    public static void Main(string[] args)
    {
        string filePath = "word.txt";
        // Initialize the game components
        IDisplay display = new Display();
        IBoard board = new Board();
        ITileBag tileBag = new TileBag();
        IDictionary wordDictionary = new Dictionary(filePath);
        List<IPlayer> player = new List<IPlayer>();

        Func<string, bool> validateWord = word => wordDictionary.isValidWord(word);
        Action<IPlayer> turnChanged = p => Console.WriteLine($"It's now {p.GetName()}'s turn.");

        Controller game = new Controller(board, display, player, tileBag, wordDictionary, validateWord, turnChanged);
        System.Console.WriteLine();

        game.StartGame();
        bool isVertical = true;

        // Main game loop
        while (!(game.GetStatus() == Status.GameCompleted))
        {
            display.DiplayBoard(game);
            IPlayer activePlayer = game.GetActivePlayer();
            if (activePlayer.GetTiles().Count == 0)
            {
                game.AssignTilesToPlayer(activePlayer);
            }
            display.DisplayTile(activePlayer);

            display.SetMessage("Choose an action:");
            display.SetMessage("1. Place a word");
            display.SetMessage("2. Pass Turn");
            display.SetMessage("3. Shuffle Rack");
            display.SetMessage("4. Switch Tiles");
            display.SetMessage("5. View Score");
            display.SetMessage("6. End Game");

            display.SetInputValue("Please enter your choice (1-6):");
            string choice = display.GetInputValue() ?? string.Empty;
            display.SetMessage($"You chose: {choice}");
            display.SetMessage($"Game Status: {game.GetStatus()}");


            switch (choice)
            {
                case "1":
                    display.SetMessage("Placing a word...");
                    System.Console.WriteLine("Enter a word to place:");
                    string word = Console.ReadLine() ?? string.Empty;

                    if (!wordDictionary.isValidWord(word))
                    {
                        Console.WriteLine("Word is not valid!");
                        game.ChangeTurn();
                        continue;
                    }
                    Console.WriteLine("Word is valid!");

                    display.SetInputValue("Enter the starting position (x,y):");
                    string[] positionInput = display.GetInputValue()?.Split(',') ?? new string[] { "0", "0" };                    int x = int.TryParse(positionInput[0], out int parsedX) ? parsedX : 0;
                    int y = int.TryParse(positionInput[1], out int parsedY) ? parsedY : 0;
                    Position startPosition = new Position(x, y);

                    display.SetInputValue("Is the word vertical? (Y / N): ");
                    isVertical = display.GetInputValue()?.Trim().ToUpper() == "Y";

                    List<Tile> tilesToPlace = new List<Tile>();
                    List<Tile> playerTiles = activePlayer.GetTiles();
                    foreach (char letter in word.ToUpper())
                    {
                        Tile? matchingTile = playerTiles.FirstOrDefault(t =>
                            t.letter == letter);
                        tilesToPlace.Add(matchingTile); // Assuming 0 as the default value for the 'int' parameter
                        playerTiles.Remove(matchingTile); // Remove the tile from the player's rack
                    }

                    Word word1 = new Word(tilesToPlace, startPosition, isVertical);
                    game.PlaceWord(activePlayer, word1);
                    game.ChangeTurn();
                    break;
                case "2":
                    display.SetMessage("Passing turn...");
                    game.PassTurn(activePlayer);
                    break;
                case "3":
                    display.SetMessage("Shuffling tile...");
                    activePlayer.ShuffleTiles();
                    continue;
                case "4":
                    display.SetMessage("Switching tiles...");
                    display.SetInputValue("Select tiles to switch:");
                    string lettertoSwitch = display.GetInputValue().ToUpper() ?? string.Empty;

                    var tilesToSwitch = activePlayer.GetTiles()
                        .Where(tile => tile != null && lettertoSwitch.Contains(tile.letter))
                        .ToList();

                    if (tilesToSwitch.Count > 0)
                    {
                        game.SwitchTile(activePlayer, tilesToSwitch);
                        game.PassTurn(activePlayer);
                    }
                    else
                    {
                        display.SetMessage("Not valid tile to switch.");
                    }
                    break;
                case "5":
                    display.SetMessage($"Current score for {activePlayer.GetName()}: {activePlayer.GetScore()}");
                    break;
                case "6":
                    display.SetMessage("Game ended by user.");
                    game.EndGame();
                    Status status = game.GetStatus();
                    break;
                default:
                    display.SetMessage("Invalid choice. Please try again.");
                    continue;
            }
        }
        display.SetMessage("\nGame Over! Thank you for playing.");
        game.CalculateFinalScore();
        IPlayer? winner = game.GameWinner();
        display.SetMessage($"The winner is: {winner?.GetName()} with a score of {winner?.GetScore()}");
        display.SetMessage("Press any key to exit...");
        Console.ReadKey();
    }
}