using System;
using System.Collections.Generic;
using System.Linq;

namespace ScrabbleGame
{
    // Class untuk representasi satu tile/huruf
    public class Tile
    {
        public char Letter { get; set; }
        public int Points { get; set; }
        
        public Tile(char letter, int points)
        {
            Letter = letter;
            Points = points;
        }
        
        public override string ToString()
        {
            return $"{Letter}({Points})";
        }
    }
    
    // Class untuk representasi posisi di board
    public class Position
    {
        public int Row { get; set; }
        public int Col { get; set; }
        
        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
    
    // Class untuk representasi kata yang ditempatkan
    public class WordPlacement
    {
        public string Word { get; set; }
        public Position StartPosition { get; set; }
        public bool IsHorizontal { get; set; }
        public List<Tile> Tiles { get; set; }
        
        public WordPlacement()
        {
            Tiles = new List<Tile>();
        }
    }
    
    // Class untuk board/papan permainan
    public class Board
    {
        private Tile[,] grid;
        private int size = 15; // Standard Scrabble board 15x15
        
        public Board()
        {
            grid = new Tile[size, size];
        }
        
        public bool PlaceWord(WordPlacement placement)
        {
            // Validasi apakah kata bisa ditempatkan
            if (!CanPlaceWord(placement))
                return false;
                
            // Tempatkan tiles di board
            for (int i = 0; i < placement.Word.Length; i++)
            {
                int row = placement.StartPosition.Row;
                int col = placement.StartPosition.Col;
                
                if (placement.IsHorizontal)
                    col += i;
                else
                    row += i;
                    
                grid[row, col] = placement.Tiles[i];
            }
            
            return true;
        }
        
        private bool CanPlaceWord(WordPlacement placement)
        {
            // Check boundaries
            int endRow = placement.StartPosition.Row;
            int endCol = placement.StartPosition.Col;
            
            if (placement.IsHorizontal)
                endCol += placement.Word.Length - 1;
            else
                endRow += placement.Word.Length - 1;
                
            if (endRow >= size || endCol >= size)
                return false;
                
            // Check if positions are empty (simplified)
            for (int i = 0; i < placement.Word.Length; i++)
            {
                int row = placement.StartPosition.Row;
                int col = placement.StartPosition.Col;
                
                if (placement.IsHorizontal)
                    col += i;
                else
                    row += i;
                    
                if (grid[row, col] != null)
                    return false;
            }
            
            return true;
        }
        
        public void DisplayBoard()
        {
            Console.WriteLine("   0 1 2 3 4 5 6 7 8 9 101112131415");
            for (int row = 0; row < size; row++)
            {
                Console.Write($"{row:D2} ");
                for (int col = 0; col < size; col++)
                {
                    if (grid[row, col] != null)
                        Console.Write($"{grid[row, col].Letter} ");
                    else
                        Console.Write(". ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
    
    // Class untuk player
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<Tile> Hand { get; set; }
        
        public Player(string name)
        {
            Name = name;
            Score = 0;
            Hand = new List<Tile>();
        }
        
        public void DisplayHand()
        {
            Console.WriteLine($"{Name}'s Hand: ");
            for (int i = 0; i < Hand.Count; i++)
            {
                Console.Write($"{i}: {Hand[i]} ");
            }
            Console.WriteLine();
        }
    }
    
    // Main Game class
    public class ScrabbleGame
    {
        private Board board;
        private List<Player> players;
        private List<Tile> tileBag;
        private Player currentPlayer;
        private int currentPlayerIndex;
        
        // Dictionary untuk nilai huruf (simplified)
        private Dictionary<char, int> letterValues = new Dictionary<char, int>
        {
            {'A', 1}, {'B', 3}, {'C', 3}, {'D', 2}, {'E', 1}, {'F', 4}, {'G', 2},
            {'H', 4}, {'I', 1}, {'J', 8}, {'K', 5}, {'L', 1}, {'M', 3}, {'N', 1},
            {'O', 1}, {'P', 3}, {'Q', 10}, {'R', 1}, {'S', 1}, {'T', 1}, {'U', 1},
            {'V', 4}, {'W', 4}, {'X', 8}, {'Y', 4}, {'Z', 10}
        };
        
        // Dictionary untuk kamus kata sederhana
        private HashSet<string> dictionary = new HashSet<string>
        {
            "CAT", "DOG", "HELLO", "WORLD", "GAME", "CODE", "PLAY", "WIN", "LOSE",
            "GOOD", "BAD", "FAST", "SLOW", "BIG", "SMALL", "HOT", "COLD"
        };
        
        public ScrabbleGame()
        {
            board = new Board();
            players = new List<Player>();
            tileBag = new List<Tile>();
            currentPlayerIndex = 0;
            
            InitializeTileBag();
        }
        
        private void InitializeTileBag()
        {
            // Simplified tile distribution
            string letters = "AAAAAAAAABBCCDDDDEEEEEEEEEEEEFFFGGGHHHIIIIIIIIIJKLLLLMMNNNNNNOOOOOOPPQRRRRRRSSSSTTTTTTUUUVVWWXYYZ";
            
            foreach (char letter in letters)
            {
                tileBag.Add(new Tile(letter, letterValues[letter]));
            }
            
            // Shuffle tiles (simplified)
            Random rand = new Random();
            tileBag = tileBag.OrderBy(x => rand.Next()).ToList();
        }
        
        public void AddPlayer(string name)
        {
            Player player = new Player(name);
            players.Add(player);
            
            // Give initial tiles (7 tiles)
            DrawTiles(player, 7);
        }
        
        private void DrawTiles(Player player, int count)
        {
            for (int i = 0; i < count && tileBag.Count > 0; i++)
            {
                player.Hand.Add(tileBag[0]);
                tileBag.RemoveAt(0);
            }
        }
        
        public void StartGame()
        {
            Console.WriteLine("=== SCRABBLE GAME STARTED ===");
            currentPlayer = players[currentPlayerIndex];
            
            while (!IsGameOver())
            {
                PlayTurn();
                NextPlayer();
            }
            
            DisplayFinalScores();
        }
        
        private void PlayTurn()
        {
            Console.WriteLine($"\n--- {currentPlayer.Name}'s Turn ---");
            board.DisplayBoard();
            currentPlayer.DisplayHand();
            Console.WriteLine($"Current Score: {currentPlayer.Score}");
            
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Place word");
            Console.WriteLine("2. Skip turn");
            Console.Write("Choose option (1-2): ");
            
            string choice = Console.ReadLine();
            
            if (choice == "1")
            {
                PlaceWordTurn();
            }
            else
            {
                Console.WriteLine("Turn skipped.");
            }
        }
        
        private void PlaceWordTurn()
        {
            Console.Write("Enter word: ");
            string word = Console.ReadLine().ToUpper();
            
            if (!IsValidWord(word))
            {
                Console.WriteLine("Invalid word or not in dictionary!");
                return;
            }
            
            if (!HasLettersForWord(word))
            {
                Console.WriteLine("You don't have the required letters!");
                return;
            }
            
            Console.Write("Enter start row (0-14): ");
            int row = int.Parse(Console.ReadLine());
            
            Console.Write("Enter start col (0-14): ");
            int col = int.Parse(Console.ReadLine());
            
            Console.Write("Horizontal? (y/n): ");
            bool isHorizontal = Console.ReadLine().ToLower() == "y";
            
            WordPlacement placement = CreateWordPlacement(word, row, col, isHorizontal);
            
            if (board.PlaceWord(placement))
            {
                int points = CalculatePoints(placement);
                currentPlayer.Score += points;
                RemoveUsedTiles(word);
                DrawTiles(currentPlayer, Math.Min(7 - currentPlayer.Hand.Count, tileBag.Count));
                
                Console.WriteLine($"Word placed! You scored {points} points.");
            }
            else
            {
                Console.WriteLine("Cannot place word at that position!");
            }
        }
        
        private WordPlacement CreateWordPlacement(string word, int row, int col, bool isHorizontal)
        {
            WordPlacement placement = new WordPlacement
            {
                Word = word,
                StartPosition = new Position(row, col),
                IsHorizontal = isHorizontal
            };
            
            foreach (char letter in word)
            {
                placement.Tiles.Add(new Tile(letter, letterValues[letter]));
            }
            
            return placement;
        }
        
        private bool IsValidWord(string word)
        {
            return dictionary.Contains(word.ToUpper());
        }
        
        private bool HasLettersForWord(string word)
        {
            var handLetters = currentPlayer.Hand.Select(t => t.Letter).ToList();
            
            foreach (char letter in word.ToUpper())
            {
                if (handLetters.Contains(letter))
                {
                    handLetters.Remove(letter);
                }
                else
                {
                    return false;
                }
            }
            
            return true;
        }
        
        private void RemoveUsedTiles(string word)
        {
            foreach (char letter in word.ToUpper())
            {
                var tile = currentPlayer.Hand.FirstOrDefault(t => t.Letter == letter);
                if (tile != null)
                {
                    currentPlayer.Hand.Remove(tile);
                }
            }
        }
        
        private int CalculatePoints(WordPlacement placement)
        {
            // Simplified scoring - just sum tile values
            return placement.Tiles.Sum(t => t.Points);
        }
        
        private void NextPlayer()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            currentPlayer = players[currentPlayerIndex];
        }
        
        private bool IsGameOver()
        {
            // Game ends when tile bag is empty and a player has no tiles
            return tileBag.Count == 0 && players.Any(p => p.Hand.Count == 0);
        }
        
        private void DisplayFinalScores()
        {
            Console.WriteLine("\n=== FINAL SCORES ===");
            var sortedPlayers = players.OrderByDescending(p => p.Score).ToList();
            
            for (int i = 0; i < sortedPlayers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedPlayers[i].Name}: {sortedPlayers[i].Score} points");
            }
            
            Console.WriteLine($"\nWinner: {sortedPlayers[0].Name}!");
        }
    }
    
    // Program utama
    public class Program
    {
        public static void Main(string[] args)
        {
            ScrabbleGame game = new ScrabbleGame();
            
            Console.WriteLine("Welcome to Scrabble!");
            Console.Write("How many players? (2-4): ");
            int playerCount = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= playerCount; i++)
            {
                Console.Write($"Enter name for Player {i}: ");
                string name = Console.ReadLine();
                game.AddPlayer(name);
            }
            
            game.StartGame();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}