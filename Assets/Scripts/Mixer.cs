using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mixer : MonoBehaviour
{
    [SerializeField] private Generator _generator;
    [SerializeField] private Button _generate;
    [SerializeField] private Button _mix;
    [SerializeField] private float _timeMix = 2;

    public void MixGrid()
    {
        int randIndex;        
        List<Vector2> positions = new List<Vector2>();

        foreach (var letter in _generator.Letters)
        {
            positions.Add(letter.transform.position);
        }

        StartCoroutine(DesableButtons());
        foreach (Letter letter in _generator.Letters)
        {           
            randIndex = Random.Range(0, positions.Count);
            StartCoroutine(ChangePosition(letter, positions[randIndex]));
            positions.RemoveAt(randIndex);
        }
    }

    private IEnumerator DesableButtons()
    {
        _generate.enabled = false;
        _mix.enabled = false;

        yield return new WaitForSeconds(_timeMix);

        _generate.enabled = true;
        _mix.enabled = true;

        StopCoroutine(DesableButtons());
    }

    private IEnumerator ChangePosition(Letter letter, Vector2 target)
    {
        float maxDistanceDelta = Vector2.Distance(letter.transform.position, target) * Time.deltaTime / _timeMix;

        while ((Vector2)letter.transform.position != target)
        {
            letter.Move(target, maxDistanceDelta);
            yield return null;
        }
        StopCoroutine(ChangePosition(letter, target));
    }
}