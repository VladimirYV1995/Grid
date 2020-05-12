using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Transform _transform;    

    public void InitLetter(char letter)
    {
        _text.text = char.ToString(letter);
    }

    public void Move(Vector2 _target, float maxDistanceDelta)
    {
        _transform.position = Vector2.MoveTowards(_transform.position, _target, maxDistanceDelta);
    }
}