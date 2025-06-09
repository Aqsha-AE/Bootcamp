using System;
using System.Collections.Generic;
using ScrabbleGame.Models;
using ScrabbleGame.Enums;
using System.IO;
using ScrabbleGame.Interface;
namespace ScrabbleGame.Models;

public class Dictionary : IDictionary
{
    private HashSet<string> _validwords = new HashSet<string>();
    public Dictionary(string filePath)
    {
        _validwords = new HashSet<string>();
        ReadFile(filePath);
    }
    public void ReadFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("‼️ File tidak ditemukan.");
            return;
        }

        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            string word = line.Trim().ToUpper();
            if (!string.IsNullOrEmpty(word))
            {
                _validwords.Add(word);
            }
        }

        Console.WriteLine($"Kamus berhasil dimuat: {_validwords.Count} kata.");
    }
    public bool isValidWord(string word)
    {
        return _validwords.Contains(word.Trim().ToUpper());
    }

}
