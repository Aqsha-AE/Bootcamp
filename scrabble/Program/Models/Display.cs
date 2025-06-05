using System;
using System.Collections.Generic;
using ScrabbleGame.Models;
using ScrabbleGame.Enums;
using ScrabbleGame.GameController;
using ScrabbleGame.Interface;
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
        _inputValue = value;
    }

    public string GetInputValue()
    {
        return _inputValue;
    }

    public string GetInfo(string text)
    {
        System.Console.WriteLine(text);
        _inputValue = Console.ReadLine() ?? string.Empty;
        return _inputValue;
    }

    public void DisplayBanner()
    {
        Console.WriteLine("========== Welcome to Scrabble Game ==========");
    }
    public Display()
    {
        _inputValue = string.Empty;
    }
}