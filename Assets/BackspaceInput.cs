using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackspaceInput : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void InputKey()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().RemoveLetter();
    }
}
