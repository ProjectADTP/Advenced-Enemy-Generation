using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnerPoint> _spawners;
    [SerializeField] private float _spawnInterval = 1f;

    private WaitForSeconds _wait;

    private void Awake()
    {
        if (_spawners.Count > 0)
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

            SpawnerPoint spawner = _spawners[Random.Range(0, _spawners.Count)];
            spawner.Initiate();

            yield return _wait;
        }
    }
}