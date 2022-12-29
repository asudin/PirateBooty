using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : ObjectPool<Enemy>
{
    [Header("Enemy Spawn Settings")]
    [SerializeField] private float _spawnInterval;
    [SerializeField] private Transform _enemySpawnPoints;
    [SerializeField] private List<Enemy> _enemyPrefabs;

    private Transform[] _enemySpawns;
    private float _elapsedTime;

    private void Start()
    {
        CreateSpawn(ref _enemySpawns, _enemySpawnPoints);
        Initialize(_enemyPrefabs);
    }

    private void FixedUpdate()
    {
        SpawnEnemies(_enemySpawns);
    }

    private void CreateSpawn(ref Transform[] spawns, Transform spawnPoints)
    {
        spawns = new Transform[spawnPoints.childCount];

        for (int i = 0; i < spawnPoints.childCount; i++)
        {
            spawns[i] = spawnPoints.GetChild(i);
        }
    }

    private void SpawnEnemies(Transform[] enemySpawns)
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnInterval)
        {
            _elapsedTime = 0;
            if (TryGetObjectInPool(out Enemy enemy))
            {
                SetEnemy(enemy, RandomSpawnPosition(enemySpawns));
                enemy.OnChestAreaEntered += OnChestAreaReached;
            }
        }
    }

    private void SetEnemy(Enemy enemy, Vector3 spawnPoint)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
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