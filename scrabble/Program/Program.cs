using ScrabbleGame.Models;
using ScrabbleGame.Enums;

namespace ScrabbleGame;
public class Program
{
    public static void Main(string[] args)
    {
        Board board = new Board();
        Cell centerCell = board.GetCell(7, 7);
        
        // Example of placing a tile
        Tile tileA = new Tile('A', 1);
        Tile tileB = new Tile('B', 3);
        Tile tileR = new Tile('R', 1);
        Tile tileD = new Tile('D', 2);
        Tile tileG = new Tile('G', 2);

        centerCell.PlaceTile(tileA);
        
        Console.WriteLine($"Tile placed at center cell: {centerCell.tile?.letter} with value {centerCell.tile?.value}");
        
        // Example of checking if the cell has a bonus
        Console.WriteLine($"Center cell has bonus: {centerCell.isHaveBonus}");
    }
}