using ScrabbleGame.Models;

namespace ScrabbleGame.Interface;

public interface IDictionary
{
    void ReadFile(string filePath);
    bool isValidWord(string word);
    
}