using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessController : MonoBehaviour
{
    [SerializeField]
    public LetterController[] _letters = new LetterController[5];

    private int _inputtingLetter;

    void Start()
    {
        _inputtingLetter = 0;
    }

    public void AddLetter(string letter, int index)
    {
        _letters[index].Change(letter);
    }

    public void RemoveLetter(int index)
    {
        _letters[index].Change("");
    }
}
