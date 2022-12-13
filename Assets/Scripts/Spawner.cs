using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [Header("Coin Spawn Settings")]
    [SerializeField] private float _coindSpawnInterval;
    [SerializeField] private Transform _coinSpawnPoints;
    [SerializeField] private Coin _coinPrefab;

    [Header("Enemy Spawn Settings")]
    [SerializeField] private float _enemySpawnInterval;
    [SerializeField] private Transform _enemySpawnPoints;
    [SerializeField] private List<Enemy> _enemyPrefabs;

    private Transform[] _coinSpawns;
    private Transform[] _enemySpawns;

    private void Start()
    {
        CreateSpawn(ref _coinSpawns, _coinSpawnPoints);
        CreateSpawn(ref _enemySpawns, _enemySpawnPoints);
        Spawn(_coindSpawnInterval, _enemySpawnInterval);
    }

    private void CreateSpawn(ref Transform[] spawns, Transform spawnPoints)
    {
        spawns = new Transform[spawnPoints.childCount];

        for (int i = 0; i < spawnPoints.childCount; i++)
        {
            spawns[i] = spawnPoints.GetChild(i);
        }
    }

    private void Spawn(float coinSpawnInterval, float enemySpawnInterval)
    {
        StartCoroutine(CreateCoins(coinSpawnInterval, _coinSpawns, _coinPrefab));
        StartCoroutine(CreateEnemies(enemySpawnInterval, _enemySpawns, _enemyPrefabs));
    }

    private IEnumerator CreateCoins(float duration, Transform[] itemSpawns, Coin coinPrefab)
    {
        var spawning = true;
        var spawnDelayTime = new WaitForSeconds(duration);

        while (spawning)
        {
            Coin newCoin = Instantiate(
                coinPrefab, 
                RandomSpawnPosition(itemSpawns), 
                Quaternion.identity);
            yield return spawnDelayTime;
        }
    }

    private IEnumerator CreateEnemies(float duration, Transform[] enemySpawns, List<Enemy> enemyPrefabs)
    {
        var spawning = true;
        var spawnDelayTime = new WaitForSeconds(duration);

        while (spawning)
        {
            var randomEnemy = Random.Range(0, enemyPrefabs.Count);

            Enemy newEnemy = Instantiate(
                enemyPrefabs[randomEnemy], 
                RandomSpawnPosition(enemySpawns), 
                Quaternion.identity);
            newEnemy.OnChestAreaEntered += OnChestAreaReached;
            yield return spawnDelayTime;
        }
    }

    private Vector3 RandomSpawnPosition(Transform[] spawns)
    {
        var randomSpawn = Random.Range(0, spawns.Length);
        var spawnPosition = new Vector3(
            spawns[randomSpawn].transform.position.x, 
            spawns[randomSpawn].transform.position.y);

        return spawnPosition;
    }

    private void OnChestAreaReached(Enemy enragedEnemy, Enemy destroyedEnemy)
    {
        Instantiate(enragedEnemy, RandomSpawnPosition(_enemySpawns), Quaternion.identity);
        destroyedEnemy.OnChestAreaEntered -= OnChestAreaReached;
    }
}