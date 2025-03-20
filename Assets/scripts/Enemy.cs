using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Transform _target;

    public void Initialise(Target target)
    {
        _target = target.transform;

        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        while (_target != null) 
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            transform.Translate(direction * _speed * Time.deltaTime, Space.World);

            yield return null;
        }
    }
}