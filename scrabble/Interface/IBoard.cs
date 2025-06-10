using ScrabbleGame.Models;
namespace ScrabbleGame.Interface;

public interface IBoard
{
    Cell GetCell(int x, int y);

}