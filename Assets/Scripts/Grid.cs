using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    [SerializeField] private RectTransform _rect;
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;

    public void SetCellSize(float width, float height)
    {
        _gridLayoutGroup.cellSize = _rect.sizeDelta / new Vector2(width, height);
    }
}
