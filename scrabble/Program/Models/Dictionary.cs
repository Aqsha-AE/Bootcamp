using System;
using System.Collections.Generic;
using ScrabbleGame.Models;
using ScrabbleGame.Enums;
using ScrabbleGame.Interface;
namespace ScrabbleGame.Models;

public class Dictionary : IDictionary
{
    private HashSet<string> _validwords;
    public string perpustakaan = @"C:\ForU\scrabble\Program\bin\Debug\net9.0";

    public void ReadFile(string perpustakaan)
    {
        if (!File.Exists(perpustakaan))
        {
            System.Console.WriteLine("File Not Found");
            return;
        }
        foreach (var line in File.ReadLines(perpustakaan))
        {
            var word = line.Trim().ToUpper();
            if (!string.IsNullOrEmpty(line))
            {
                _validwords.Add(word);
            }
        }
        System.Console.WriteLine($"Dictinory loaded : {_validwords.Count} words");
    }

    public Dictionary()
    {
        _validwords = new HashSet<string>();
    }
    public bool isValidWord(string word)
    {
        return _validwords.Contains(word.ToUpper());
    }
}
