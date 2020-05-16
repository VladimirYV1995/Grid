using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    [SerializeField] private InputField _width;
    [SerializeField] private GameObject _wrongWidth;
    [SerializeField] private InputField _height;
    [SerializeField] private GameObject _wrongHeight;
    [SerializeField] private Grid _grid;
    [SerializeField] private Transform _container;
    [SerializeField] private Letter _template;

    private string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private List<Letter> _letters;
    public List<Letter> Letters => _letters;

    public void GenerateGrid()
    {
        int randIndex;
        int width = CheckInput(_width, _wrongWidth);
        int height = CheckInput(_height, _wrongHeight);        

        if (width > 0 && height > 0)
        {
            ClearGrid();
            _grid.SetCellSize(width, height);

            _letters = new List<Letter>();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Letter letter = Instantiate(_template, _container);                   
                    randIndex = Random.Range(0, _alphabet.Length);
                    letter.InitLetter(_alphabet[randIndex]);
                    _letters.Add(letter);
                }
            }
        }         
    }

    private int CheckInput(InputField field, GameObject panelWrong)
    {
        if (int.TryParse(field.text, out int linearSize) == false || linearSize < 1)
        {
            panelWrong.SetActive(true);
        }
        return linearSize;
    }

    private void ClearGrid()
    {
        for (int i = 0; i < _container.childCount; i++)
        {
            if(_container.GetChild(i).TryGetComponent(out Letter letter))
            {
                letter.Delete();
            }
        }
    }
}