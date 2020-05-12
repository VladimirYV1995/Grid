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

    [SerializeField] private RectTransform _grid;
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;
    [SerializeField] private Transform _container;
    

    [SerializeField] private Letter _template;

    public List<Letter> Letters => _letters;
    private List<Letter> _letters;
    private string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public void GenerateGrid()
    {
        int width = CheckInput(_width, _wrongWidth);
        int height = CheckInput(_height, _wrongHeight);
        int randIndex;

        if (width > 0 && height > 0)
        {
            ClearGrid();

            _gridLayoutGroup.cellSize = _grid.sizeDelta / new Vector2(width, height);

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
            Destroy(_container.GetChild(i).gameObject);
        }
    }
}