using ScrabbleGame.Models;
using ScrabbleGame.GameController;
using ScrabbleGame.Enums;

namespace ScrabbleGame.Interface;

public interface IDisplay
{
    void SetMessage(string message);
    void SetInputValue(string value);
    string GetInputValue();
    string GetInfo(string text);
    void DisplayBanner();
    void DisplayTile(IPlayer player);
    void DisplayPlacementError(validateResult result);
    void DisplayBoard(IBoard board);
    void DisplayMenu();

}