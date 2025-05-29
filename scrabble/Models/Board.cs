namespace Scrabble;
using Scrabble.Interfaces;
using Scrabble.Enums;


{
    public class Cell
    {
        public int x { get; }
        public int y { get; }
        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        const int totalRows = 15;
        const int totalColumns = 15;

        public GameSquare[,] Squares { get; private set; }

        public GameBoard()
        {
            Squares = new GameSquare[totalRows, totalColumns];
            for (int r = 0; r < totalRows; r++)
            {
                for (int c = 0; c < totalColumns; c++)
                {
                    Squares[r, c] = new GameSquare(r, c, totalRows, totalColumns);
                }
            }
        }
    }
    private Cell[,] _grid;
}