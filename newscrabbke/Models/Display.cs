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

    public void DiplayBoard(Controller controller)
    {
        controller.DisplayB();
    }

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
            Console.WriteLine($"{Name}'s Tile: {string.Join(" ", Tiles.Select(t => t.letter))}");
        }
        Console.WriteLine();
    }

    public Display()
    {
        _inputValue = string.Empty;
    }
    
}