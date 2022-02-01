using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class WordExtractor
{
    private static string _answers = @"Assets\Lists\wordleList.txt";
    private static string _validGuesses = @"Assets\Lists\wordleValid.txt";

    public static string GetWord()
    {
        if (!File.Exists(_answers))
        {
            Debug.LogError($"referenced file does not exist; defaulting to ADEIU\npath: {Path.GetFullPath(_answers)}");
            return "ADIEU";
        }

        string[] _allPotentialWords = File.ReadAllLines(_answers);
        return _allPotentialWords[UnityEngine.Random.Range(0, _allPotentialWords.Length)];
    }

    public static bool IsValidWord(string word)
    {
        if (!File.Exists(_validGuesses))
        {
            Debug.LogError($"referenced file does not exist; defaulting to true\npath: {Path.GetFullPath(_validGuesses)}");
            return true;
        }

        List<string> _allPotentialWords = File.ReadAllLines(_validGuesses).ToList();
        _allPotentialWords.AddRange(File.ReadAllLines(_answers).ToList());
        if (_allPotentialWords.Contains(word))
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
