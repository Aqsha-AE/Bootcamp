using ScrabbleGame.Models;

namespace ScrabbleGame.Interface;

public interface IWord
{    
    string? word { get; }
    List<Tile>? tiles { get; }
    Position? starting { get; }
    bool isVertical { get; }
    List<Position> GetFixPosition();
    
}
