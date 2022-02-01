using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string Word = "ADEIU";

    [SerializeField]
    private GuessController[] _guessControllers = new GuessController[6];

    private int _inputtingGuess;
    private int _inputtingLetter;
    private string _guess = "";
    private bool _isBusyAnimating = false;

    void Start()
    {
        _inputtingGuess = 0;
        ResetWord();
    }

    void Update()
    {
        
    }

    void OnGUI()
    {
        if (_isBusyAnimating)
            return;

        Event e = Event.current;
        if (e.isKey && Input.anyKeyDown)
        {
            KeyCode key = e.keyCode;
            if (key.ToString().Length == 1 && _inputtingLetter < 5)
            {
                _guessControllers[_inputtingGuess].AddLetter(key.ToString(), _inputtingLetter++);
                _guess += key.ToString();
            }

            else if (key == KeyCode.Backspace && _inputtingLetter > 0)
            {
                _guessControllers[_inputtingGuess].RemoveLetter(--_inputtingLetter);
                _guess = _guess.Substring(0, _inputtingLetter);
            }

            else if (key == KeyCode.Return && _inputtingLetter > 4)
            {
                StartCoroutine(Check());
            }
        }
    }

    private IEnumerator Check()
    {
        _isBusyAnimating = true;

        LetterController[] letters = _guessControllers[_inputtingGuess]._letters;
        for (int i = 0; i < 5; i++)
        {
            var letter = letters[i];
            if (Word[i] == _guess[i])
            {
                yield return StartCoroutine(letter.TurnGreen());
            }

            else if (Word.Contains(_guess[i].ToString()))
            {
                yield return StartCoroutine(letter.TurnYellow());
            }

            else
            {
                yield return StartCoroutine(letter.TurnGrey());
            }
        }

        if (Word == _guess)
        {
            Win();
        }

        else
        {
            _inputtingGuess++;
            ResetWord();
            _isBusyAnimating = false;
        }
    }

    private void ResetWord()
    {
        _inputtingLetter = 0;
        _guess = "";
    }
    
    private void Win()
    {
        StartCoroutine(WinAnimation());
    }

    private IEnumerator WinAnimation()
    {
        foreach (GuessController guess in _guessControllers)
        {
            foreach (LetterController letter in guess._letters)
            {
                StartCoroutine(letter.Bounce());
                yield return new WaitForSeconds(0.02f);
            }
        }
    }
}
