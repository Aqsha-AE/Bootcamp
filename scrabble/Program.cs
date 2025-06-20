﻿using ScrabbleGame.Models;
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
        Queue<ITile> tiles = new Queue<ITile>();

        //GantiAction
        Action<string> validateWord = word =>
        {
            bool isValid = wordDictionary.isValidWord(word);
            Console.WriteLine($"Kata '{word}' valid? {isValid}");
        };
        Action<IPlayer> turnChanged = p => Console.WriteLine($"It's now {p.GetName()}'s turn.");

        Controller game = new Controller(board, display, player, tiles, tileBag, wordDictionary, validateWord, turnChanged);
        System.Console.WriteLine();

        display.DisplayBanner();
        string numPlayersInput = display.GetInfo("Berapa banyak pemain yang ingin bermain?");
        int numPlayers = int.Parse(numPlayersInput);
        while (numPlayers < 2 || numPlayers > 4)
        {
            display.SetMessage("Jumlah pemain harus antara 2 dan 4.");
            numPlayersInput = display.GetInfo("Masukkan jumlah pemain yang valid (2-4):");
            numPlayers = int.Parse(numPlayersInput);
        }

        for (int i = 1; i <= numPlayers; i++)
        {
            string name = display.GetInfo($"Masukkan nama pemain {i}: ");
            player.Add(new Player(name));
        }
        game.StartGame();

        display.SetMessage("Permainan dimulai!");
        display.SetMessage(" ");
        bool isVertical = true;

        // Main game loop
        while (!(game.GetStatus() == Status.GameCompleted))
        {
            display.DisplayBoard(board);
            IPlayer activePlayer = game.GetActivePlayer();
            if (activePlayer.GetTiles().Count == 0)
            {
                game.AssignTilesToPlayer(activePlayer);
            }
            display.DisplayTile(activePlayer);
            display.DisplayMenu();
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

                    List<ITile> tilesToPlace = new List<ITile>();
                    List<ITile> playerTiles = activePlayer.GetTiles();
                    foreach (char letter in word.ToUpper())
                    {
                        ITile? matchingTile = playerTiles.FirstOrDefault(t =>
                            t.Letter == letter);
                        tilesToPlace.Add(matchingTile); 
                        playerTiles.Remove(matchingTile); 
                    }

                    IWord word1 = new Word(tilesToPlace, startPosition, isVertical);
                    validateResult result = game.ValidateWordPlacement(word1);
                    if (result == validateResult.Success)
                    {
                        game.PlaceWord(activePlayer, word1);
                        game.ChangeTurn();
                    }
                    else
                    {
                        display.DisplayPlacementError(result);
                    }
                    int score = game.ApplyBonus(word1);
                    display.SetMessage($"{activePlayer.GetName()} mendapatkan skor {score}.");
                    break;
                case "2":
                    display.SetMessage("Passing turn...");
                    display.SetMessage($"{activePlayer.GetName()} melewati turn.");
                    game.ChangeTurn();
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
                        .Where(tile => tile != null && lettertoSwitch.Contains(tile.Letter))
                        .ToList();

                    var tilesToSwitchAsITile = tilesToSwitch.Cast<ITile>().ToList();

                    if (tilesToSwitchAsITile.Count > 0)
                    {
                        game.SwitchTile(activePlayer, tilesToSwitchAsITile);
                        game.ChangeTurn();
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
        List<IPlayer> winners = game.GetWinner();
        if (winners != null && winners.Count > 0)
        {
            if (winners.Count == 1)
            {
            var winner = winners[0];
            display.SetMessage($"The winner is: {winner.GetName()} with a score of {winner.GetScore()}");
            }
            else
            {
            display.SetMessage("It's a tie between:");
            foreach (var winner in winners)
            {
                display.SetMessage($"{winner.GetName()} with a score of {winner.GetScore()}");
            }
            }
        }
        else
        {
            display.SetMessage("No winner could be determined.");
        }
        display.SetMessage("Press any key to exit...");
        Console.ReadKey();
    }
}