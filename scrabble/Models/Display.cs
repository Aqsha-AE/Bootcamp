using System;
using System.Collections.Generic;
using ScrabbleGame.Models;
using ScrabbleGame.Enums;
using ScrabbleGame.GameController;
using ScrabbleGame.Interface;
using System.Diagnostics.Contracts;
namespace ScrabbleGame.Models;

public class Display : IDisplay
{
    private string _inputValue;
    public const int BoardSize = 15;
    //ganti ini 

    public void SetMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void SetInputValue(string value)
    {
        Console.Write(value);
        this._inputValue = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("");
    }

    public string GetInputValue()
    {
        return this._inputValue;
    }

    public string GetInfo(string text)
    {
        System.Console.WriteLine(text);
        _inputValue = Console.ReadLine() ?? string.Empty;
        return _inputValue;
    }

    public void DisplayBanner()
    {
        Console.WriteLine(@"
      ██████  ██████   ██████      ██████   ██████    ██████   ██      ███████ 
     ██       ██    ██ ██    ██   ███  ███ ██     ██ ██     ██ ██      ██
     ██       ██       ██     ██  ██    ██ ██     ██ ██     ██ ██      ██
      ██████  ██             ██   █      █ ███████   ███████   ██      █████
           ██ ██       ██ ███     ████████ ██     ██ ██     ██ ██      ██ 
           ██ ██    ██ ██    ██   ██    ██ ██     ██ ██     ██ ██      ██ 
      ██████  ██████   ██      ██ ██    ██  ██████    ██████    ██████ ███████         
");
    }
    public void DisplayTile(IPlayer player)
    {
        var Tiles = player.GetTiles();
        var Name = player.GetName();

        if (Tiles == null || Tiles.Count == 0)
        {
            Console.WriteLine($"{Name}'s Tile: (Empty)");
        }
        else
        {
            Console.WriteLine($"{Name}'s Tile: {string.Join(" ", Tiles.Select(t => t.Letter))}");
        }
        Console.WriteLine();
    }

    public void DisplayMenu()
    {
            System.Console.WriteLine("Choose an action:");
            System.Console.WriteLine("1. Place a word");
            System.Console.WriteLine("2. Pass Turn");
            System.Console.WriteLine("3. Shuffle Rack");
            System.Console.WriteLine("4. Switch Tiles");
            System.Console.WriteLine("5. View Score");
            System.Console.WriteLine("6. End Game");
    }

    public Display()
    {
        _inputValue = string.Empty;
    }

    public void DisplayPlacementError(validateResult result)
    {
        if (result == validateResult.Success) return;

        string message = "TryAgain";
        switch (result)
        {
            case validateResult.InvalidWord:
                message += "tidak ada tile atau posisi tidak valid.";
                break;
            case validateResult.NotAligned:
                message += "Tile harus dalam horizontal atau vertikal.";
                break;
            case validateResult.InvalidOverlap:
                message += "Kata tidak overlap ";
                break;
            case validateResult.FirstWordNotCentered:
                message += "Kata pertama harus coordinat 7,7";
                break;
            case validateResult.NotConnected:
                message += "Kata tidak terhubung";
                break;
            default:
                message += "Terjadi penempataan yang tidak diketahui";
                break;
        }
        System.Console.WriteLine(message);
    }

    public void DisplayBoard(IBoard board)
    {
        Console.WriteLine("\n    00 | 01 | 02 | 03 | 04 | 05 | 06 | 07 | 08 | 09 | 10 | 11 | 12 | 13 | 14 |");
        Console.WriteLine("  ┌────+────+────+────+────+────+────+────+────+────+────+────+────+────+────┐");
        for (int i = 0; i < BoardSize; i++)
        {
            System.Console.Write($"{i:D2}|");
            for (int j = 0; j < BoardSize; j++)
            {
                var square = board.GetCell(i, j); // Use the board interface to get the square
                if (square.isFilled)
                {
                    Console.Write($" {square.tile?.Letter.ToString() ?? "  "} |");
                }
                else
                {
                    if (i == 7 && j == 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; 
                        Console.Write(" s  ");
                        Console.ResetColor();
                        Console.Write("|"); 
                    }
                    else
                    {
                        switch (square.Bonus)
                        {
                            case BonusSquareType.TripleWord:
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write(" 3W ");
                                Console.ResetColor();
                                Console.Write("|");
                                break;
                            case BonusSquareType.DoubleWord:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" 2W |");
                                Console.ResetColor();
                                break;
                            case BonusSquareType.TripleLetter:
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.Write(" 3W ");
                                Console.ResetColor();
                                Console.Write("|");
                                break;
                            case BonusSquareType.DoubleLetter:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(" 2L ");
                                Console.ResetColor();
                                Console.Write("|");
                                break;
                            default:
                                Console.Write("    |");
                                break;
                        }
                    }
                }
            }
            System.Console.WriteLine();
            System.Console.WriteLine("  └────+────+────+────+────+────+────+────+────+────+────+────+────+────+────┘");
        }
    }
}