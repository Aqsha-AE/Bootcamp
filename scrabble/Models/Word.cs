namespace ScrabbleGame.Models;
using Scrabble.Interfaces;
using Scrabble.Enums;
using System.Collections.Generic;

public class Word
{
    public List<Tile> Tiles { get; set; }
    public Position starting { get; set; }
    public bool IsVertical { get; set; }
    public Word(List<Tile> Tiles, Position starting, bool vertical)
    {
        Tiles = Tiles ?? new List<Tile>();
        starting = starting;
        IsVertical = vertical;
    }
    public List<Position> GetFixPositions()
    {
        List<Posistion> wordPosisitions = new List<Posistion>(); 
        if (Tiles == null || Tiles.Count == 0)
        {
            return wordPositions;
        }

        currentX = Starting.X
        currentY = Starting.Y;

        foreach (var tile ini Tiles){

            wordPosisitions.Add(new Position(currentX, currentY));
            if (IsVertical)
            {
                currentY++;
            }
            else
            {
                currentX++;
            }
        }
        return wordPositions;
    }
}
