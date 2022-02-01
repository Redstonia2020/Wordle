using System.Collections;
using TMPro;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    
    [SerializeField]
    private SpriteRenderer _contentSprite;
    [SerializeField]
    private SpriteRenderer _outlineSprite;

    private int _rotationSteps = 25;
    private float _rotationDuration = 0.25f;

    private int _bounceSteps = 25;
    private float _bounceDuration = 0.1f;
    
    void Start()
    {
        Change("");
    }

    void Update()
    {
        
    }

    public void Change(string newString)
    {
        _text.text = newString;
    }

    public IEnumerator TurnGrey()
    {
        yield return StartCoroutine(SpinStart());
        _outlineSprite.color = new Color32(123, 123, 123, 255);
        StartCoroutine(SpinEnd());
    }

    public IEnumerator TurnYellow()
    {
        yield return StartCoroutine(SpinStart());
        _outlineSprite.color = new Color32(204, 181, 90, 255);
        StartCoroutine(SpinEnd());
    }

    public IEnumerator TurnGreen()
    {
        yield return StartCoroutine(SpinStart());
        _outlineSprite.color = new Color32(109, 170, 102, 255);
        StartCoroutine(SpinEnd());

    }

    public IEnumerator SpinStart()
    {
        for (int i = 0; i < _rotationSteps; i++)
        {
            transform.Rotate(new Vector3(90f / _rotationSteps, 0, 0));
            yield return new WaitForSeconds(_rotationDuration / _rotationSteps);
        }

        _contentSprite.enabled = false;
    }

    public IEnumerator SpinEnd()
    {
        for (int i = 0; i < _rotationSteps; i++)
        {
            transform.Rotate(new Vector3(-90f / _rotationSteps, 0, 0));
            yield return new WaitForSeconds(_rotationDuration / _rotationSteps);
        }
    }

    public IEnumerator Bounce()
    {
        for (int i = 0; i < _bounceSteps; i++)
        {
            transform.position += new Vector3(0, 0.5f / _bounceSteps, 0);
            yield return new WaitForSeconds(_bounceDuration / _bounceSteps);
        }

        for (int i = 0; i < _bounceSteps; i++)
        {
            transform.position -= new Vector3(0, 0.5f / _bounceSteps, 0);
            yield return new WaitForSeconds(_bounceDuration / _bounceSteps);
        }
    }
}
