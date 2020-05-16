using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mixer : MonoBehaviour
{
    [SerializeField] private Generator _generator;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private float _timeMix = 2;

    public void MixGrid()
    {
        int randIndex;        
        List<Vector2> positions = new List<Vector2>();
        List<Movement> movements = new List<Movement>();

        foreach (var letter in _generator.Letters)
        {
            positions.Add(letter.transform.position);
            if (letter.TryGetComponent(out Movement movement))
            {
                movements.Add(movement);
            }
        }

        foreach (Movement movement in movements)
        {           
            randIndex = Random.Range(0, positions.Count);
            movement.SetTarget(positions[randIndex], _timeMix);
            positions.RemoveAt(randIndex);
        }
        StartCoroutine(ChangePositions(movements));
    }   

    private IEnumerator ChangePositions(List<Movement> movements)
    {
        float currentTime = 0;

        EnableButtons(false);
        while (currentTime < _timeMix)
        {
            foreach (Movement movement in movements)
            {
                movement.Move();
                
            }
            currentTime += Time.deltaTime;
            yield return null;
        }
        EnableButtons(true);

        StopCoroutine(ChangePositions(movements));        
    }

    private void EnableButtons(bool isEnable)
    {
        foreach (Button button in _buttons)
        {
            button.enabled = isEnable;
        }
    }
}