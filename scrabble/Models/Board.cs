using System;
using System.Collections.Generic;
using ScrabbleGame.Models;
using ScrabbleGame.Enums;
using ScrabbleGame.Interface;
namespace ScrabbleGame.Models;

public class Board : IBoard
{
    public Cell[,] _grid { get; private set; }
    public const int BoardSize = 15;

    public Board()
    {
        _grid = new Cell[BoardSize, BoardSize];
        SetBoard();
        CoordinateBonusSquares();
    }

    private void SetBoard()
    {
        for (int x = 0; x < BoardSize; x++)
        {
            for (int y = 0; y < BoardSize; y++)
            {
                _grid[x, y] = new Cell();
            }
        }
    }
    private void CoordinateBonusSquares() 
    {
        var BonusSquares = new Dictionary<BonusSquareType, int[,]>
        {
            [BonusSquareType.DoubleLetter] = new int[,]
            { {3, 0}, {11, 0}, {6, 2}, {8, 2}, {0, 3},
              {7, 3}, {14, 3}, {2, 6}, {6, 6},{8, 6},
              {12, 6}, {3, 7}, {11, 7}, {2, 8}, {6, 8},
              {8, 8}, {12, 8}, {0, 11},{7, 11}, {14, 11},
              { 6, 12}, {8, 12}, {3, 14}, {11, 14}
            },

            [BonusSquareType.TripleLetter] = new int[,]
            { {5, 1}, {9, 1}, {1, 5}, {5, 5}, {9, 5},
              {13, 5}, {1, 9}, {5, 9}, {9, 9}, {13, 9},
              {5, 13}, {9, 13}
            },

            [BonusSquareType.DoubleWord] = new int[,]
            { {1, 1}, {2, 2}, {3, 3}, {4, 4}, {10, 10},
              { 11, 11}, {12, 12}, {13, 13}, {14, 14},
              { 13,1}, {12,2}, {11, 3}, {10, 4}, 
              {1, 13}, {2, 12}, {3, 11}, {4,10}
            },

            [BonusSquareType.TripleWord] = new int[,]
            { {0, 0}, {7, 0}, {14, 0}, {0, 7}, {14, 14},
              {14, 7}, {0, 14}, {7, 14}
            }
        };

        foreach (var entry in BonusSquares)
        {
            AssigningBonusToCells(entry.Key, entry.Value);
        }
    }
    public void AssigningBonusToCells(BonusSquareType bonusType, int[,] squares)
    {
        for (int i = 0; i < squares.GetLength(0); i++)
        {
            _grid[squares[i, 0], squares[i, 1]].Bonus = bonusType;
        }
    }
    public Cell GetCell(int x, int y) => _grid[x, y];
}