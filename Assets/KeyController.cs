using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    void Start()
    {
        _text.text = gameObject.name;
    }

    void Update()
    {

    }

    public void InputKey()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().AddLetter(gameObject.name);
    }

    public void ChangeColor(Color32 color)
    {
        gameObject.GetComponent<Image>().color = color;
        _text.color = new Color32(255, 255, 255, 255);
    }
}
