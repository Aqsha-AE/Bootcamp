using ScrabbleGame.Models;

namespace ScrabbleGame.Interface;

public interface ITile
{
    char Letter { get; }
    int Value { get; }
    bool isBlanktile{ get; }
}