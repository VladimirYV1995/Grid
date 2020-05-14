using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private Vector2 _target;
    private float _maxDistanceDelta;

    public void SetTarget(Vector2 target, float timeMix)
    {
        _target = target;
        _maxDistanceDelta = Vector2.Distance(_transform.position, _target) * Time.deltaTime / timeMix;
    }

    public void Move()
    {
        _transform.position = Vector2.MoveTowards(_transform.position, _target, _maxDistanceDelta);
    }
}
