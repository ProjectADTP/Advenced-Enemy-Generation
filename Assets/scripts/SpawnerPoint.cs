using System.Collections.Generic;
using UnityEngine;

public class SpawnerPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<Target> _targerPoints;

    public void Initiate()
    {
        if (_targerPoints.Count > 0)
        {
            Enemy enemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);
            enemy.Initialise(_targerPoints[Random.Range(0, _targerPoints.Count)]);
        }
    }
}
