using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    [SerializeField] private TargetPoint[] _waypoints;

    private int _currentWaypoint = 0;

    private void Start()
    {
        StartCoroutine(MoveToPoints());
    }

    private IEnumerator MoveToPoints()
    {
        while (_currentWaypoint < _waypoints.Length)
        {
            if (transform.position == _waypoints[_currentWaypoint].transform.position)
            {
                int newWaypointIndex;

                do
                {
                    newWaypointIndex = Random.Range(0, _waypoints.Count()); 
                } 
                while (newWaypointIndex == _currentWaypoint);

                _currentWaypoint = newWaypointIndex;
            }

            transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].transform.position, _speed * Time.deltaTime);

            yield return null;
        }

        _currentWaypoint = 0;
    }
}
