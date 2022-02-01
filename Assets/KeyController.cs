using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
}
