using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string Word = "ADIEU";

    [SerializeField]
    private GuessController[] _guessControllers = new GuessController[6];
    [SerializeField]
    private GameObject _keyboard;

    private int _inputtingGuess;
    private int _inputtingLetter;
    private string _guess = "";
    private bool _isBusyAnimating = false;

    void Start()
    {
        Word = WordExtractor.GetWord();
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

            if (key.ToString().Length == 1)
                AddLetter(key.ToString());

            else if (key == KeyCode.Backspace)
                RemoveLetter();

            else if (key == KeyCode.Return)
                StartCheck();
        }
    }

    public void AddLetter(string letter)
    {
        if (_inputtingLetter < 5)
        {
            _guessControllers[_inputtingGuess].AddLetter(letter, _inputtingLetter++);
            _guess += letter;
        }
    }

    public void RemoveLetter()
    {
        if (_inputtingLetter > 0)
        {
            _guessControllers[_inputtingGuess].RemoveLetter(--_inputtingLetter);
            _guess = _guess.Substring(0, _inputtingLetter);
        }
    }

    public void StartCheck()
    {
        if (_inputtingLetter > 4)
        {
            if (WordExtractor.IsValidWord(_guess))
            {
                StartCoroutine(Check());
            }

            else
            {
                StartCoroutine(_guessControllers[_inputtingGuess].ShakeIncorrect());
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
                ChangeKeyboardColor(_guess[i].ToString(), new Color32(109, 170, 102, 255));
            }

            else if (Word.Contains(_guess[i].ToString()))
            {
                yield return StartCoroutine(letter.TurnYellow());
                ChangeKeyboardColor(_guess[i].ToString(), new Color32(204, 181, 90, 255));
            }

            else
            {
                yield return StartCoroutine(letter.TurnGrey());
                ChangeKeyboardColor(_guess[i].ToString(), new Color32(123, 123, 123, 255));
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

    private void ChangeKeyboardColor(string key, Color32 color)
    {
        foreach (Transform child in _keyboard.transform)
        {
            var potentialSubject = child.Find(key);
            if (potentialSubject != null)
            {
                potentialSubject.GetComponent<KeyController>().ChangeColor(color);
            }
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
                yield return new WaitForSeconds(0.015f);
            }
        }
    }
}
