using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnerPoint> _spawnerPoints;
    [SerializeField] private float _spawnInterval = 3f;

    private WaitForSeconds _wait;

    private void Awake()
    {
        if (_spawnerPoints.Count > 0)
        {
            _wait = new WaitForSeconds(_spawnInterval);

            StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _spawnInterval)
        {
            elapsedTime += Time.deltaTime;

            SpawnerPoint spawnerPoint = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)];
            spawnerPoint.Initiate();

            yield return _wait;
        }
    }
}