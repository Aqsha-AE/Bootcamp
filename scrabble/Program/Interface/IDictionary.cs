using ScrabbleGame.Models;

namespace ScrabbleGame.Interface;

public interface IDictionary
{
    bool isValidWord(string word);
    void ReadFile(string perpustakaan);
}