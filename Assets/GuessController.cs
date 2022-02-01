using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessController : MonoBehaviour
{
    [SerializeField]
    public LetterController[] _letters = new LetterController[5];

    private int _inputtingLetter;

    private int _shakeSteps = 4;
    private float _shakeDuration = 0.25f;
    private int _shakeTimes = 3;
    private float _shakeTo = 0.25f;

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

    public IEnumerator ShakeIncorrect()
    {
        for (int i = 0; i < _shakeTimes; i++)
        {
            for (int j = 0; j < _shakeSteps; j++)
            {
                transform.position += new Vector3(_shakeTo / _shakeSteps, 0);
                yield return new WaitForSeconds(_shakeDuration / _shakeSteps / _shakeTimes / 4);
            }

            for (int j = 0; j < _shakeSteps * 2; j++)
            {
                transform.position -= new Vector3(_shakeTo / _shakeSteps, 0);
                yield return new WaitForSeconds(_shakeDuration / _shakeSteps / _shakeTimes / 4);
            }

            for (int j = 0; j < _shakeSteps; j++)
            {
                transform.position += new Vector3(_shakeTo / _shakeSteps, 0);
                yield return new WaitForSeconds(_shakeDuration / _shakeSteps / _shakeTimes / 4);
            }
        }
    }
}
