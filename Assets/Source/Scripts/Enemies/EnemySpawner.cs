using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Enemy _enemyPrefab;

    private Transform[] _spawns;

    private void Start()
    {
        _spawns = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _spawns[i] = _spawnPoints.GetChild(i);
        }

        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        var spawningInterval = 4f;

        StartCoroutine(CreateEnemies(spawningInterval, _enemyPrefab));
    }

    private IEnumerator CreateEnemies(float duration, Enemy enemyPrefab)
    {
        var spawning = true;
        var spawnDelayTime = new WaitForSeconds(duration);

        while (spawning)
        {
            var randomSpawn = Random.Range(0, _spawns.Length);
            var spawnPosition = new Vector3(_spawns[randomSpawn].transform.position.x, _spawns[randomSpawn].transform.position.y);

            Enemy newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            yield return spawnDelayTime;
        }
    }
}