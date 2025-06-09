using ScrabbleGame.Models;
using ScrabbleGame.GameController;

namespace ScrabbleGame.Interface;

public interface IDisplay
{
    void SetMessage(string message);
    void SetInputValue(string value);
    string GetInputValue();
    string GetInfo(string text);

    void DisplayBanner();
    void DiplayBoard(Controller controller);
    void DisplayTile(IPlayer player);

}