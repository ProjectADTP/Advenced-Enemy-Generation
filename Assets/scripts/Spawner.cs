using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<Target> _targerPoints;

    public void Initiate()
    {
        if (_targerPoints.Count > 0)
        {
            Enemy enemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);
            enemy.AssignPath(_targerPoints);
        }
    }
}
