using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Transform[] _waypoints;

    private int _currentWaypoint = 0;

    private IEnumerator MoveToTargets()
    {
        while (_currentWaypoint < _waypoints.Length - 1) 
        {
            if (transform.position == _waypoints[_currentWaypoint].position)
                _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;
           
            transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);

            yield return null;
        } 
    }

    public void AssignPath(List<Target> targets)
    {
        _waypoints = new Transform[targets.Count];

        int i = 0;

        foreach (var target in targets)
        {
            _waypoints[i] = target.transform;
            i++;
        }

        StartCoroutine(MoveToTargets());
    }
}
