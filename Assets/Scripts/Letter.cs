using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void InitLetter(char letter)
    {
        _text.text = char.ToString(letter);
    }   

    public void Delete()
    {
        Destroy(gameObject);
    }
}