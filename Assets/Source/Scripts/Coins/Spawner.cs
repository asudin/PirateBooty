using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _coinSpawnPoints;
    [SerializeField] private Transform _enemySpawnPoints;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private List<Enemy> _enemyPrefabs;

    private Transform[] _coinSpawns;
    private Transform[] _enemySpawns;

    private void Start()
    {
        CreateSpawn(ref _coinSpawns, _coinSpawnPoints);
        CreateSpawn(ref _enemySpawns, _enemySpawnPoints);
        SpawnItems();
    }

    private void CreateSpawn(ref Transform[] itemSpawns, Transform spawnPoints)
    {
        itemSpawns = new Transform[spawnPoints.childCount];

        for (int i = 0; i < spawnPoints.childCount; i++)
        {
            itemSpawns[i] = spawnPoints.GetChild(i);
        }
    }

    private void SpawnItems()
    {
        var spawningInterval = 4f;

        StartCoroutine(CreateCoins(spawningInterval, _coinSpawns, _coinPrefab));
        StartCoroutine(CreateEnemies(spawningInterval, _enemySpawns, _enemyPrefabs));
    }

    private IEnumerator CreateCoins(float duration, Transform[] itemSpawns, Coin coinPrefab)
    {
        var spawning = true;
        var spawnDelayTime = new WaitForSeconds(duration);

        while (spawning)
        {
            var randomSpawn = Random.Range(0, itemSpawns.Length);
            var spawnPosition = new Vector3(itemSpawns[randomSpawn].transform.position.x, itemSpawns[randomSpawn].transform.position.y);

            Coin newCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
            yield return spawnDelayTime;
        }
    }

    private IEnumerator CreateEnemies(float duration, Transform[] itemSpawns, List<Enemy> enemyPrefabs)
    {
        var spawning = true;
        var spawnDelayTime = new WaitForSeconds(duration);

        while (spawning)
        {
            var randomSpawn = Random.Range(0, itemSpawns.Length);
            var randomEnemy = Random.Range(0, enemyPrefabs.Count);
            var spawnPosition = new Vector3(itemSpawns[randomSpawn].transform.position.x, itemSpawns[randomSpawn].transform.position.y);

            Enemy newEnemy = Instantiate(enemyPrefabs[randomEnemy], spawnPosition, Quaternion.identity);
            yield return spawnDelayTime;
        }
    }
}