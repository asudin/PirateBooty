using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [Header("Coin Spawn Settings")]
    [SerializeField] private float _spawnInterval;
    [SerializeField] private Transform _coinSpawnPoints;
    [SerializeField] private Coin _coinPrefab;

    [Header("Enemy Spawn Settings")]
    [SerializeField] private float _enemySpawnInterval;
    [SerializeField] private Transform _enemySpawnPoints;
    [SerializeField] private List<Enemy> _enemyPrefabs;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private Transform[] _coinSpawns;
    private Transform[] _enemySpawns;
    private List<Enemy> _pool = new List<Enemy>();
    private float _elapsedTime;

    private void Start()
    {
        CreateSpawn(ref _coinSpawns, _coinSpawnPoints);
        CreateSpawn(ref _enemySpawns, _enemySpawnPoints);
        Spawn(_spawnInterval, _enemySpawnInterval);
        Initialize(_container, _enemyPrefabs);
    }

    private void FixedUpdate()
    {
        SpawnEnemies(_enemySpawns);
    }

    protected void Initialize(GameObject container, List<Enemy> enemyPrefabs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Enemy spawned = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], container.transform);
            spawned.gameObject.SetActive(false);
            spawned.OnChestAreaEntered += OnChestAreaReached;
            _pool.Add(spawned);
        }
    } 

    protected bool TryGetObject(out Enemy result)
    {
        result = _pool[Random.Range(0, _pool.Count - 1)];
        return result.gameObject.activeSelf == false;
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
        //StartCoroutine(CreateEnemies(enemySpawnInterval, _enemySpawns));
    }

    private IEnumerator CreateCoins(float duration, Transform[] itemSpawns, Coin coinPrefab)
    {
        var spawning = true;
        var spawnDelayTime = new WaitForSeconds(duration);

        while (spawning)
        {
           Instantiate(
                coinPrefab,
                RandomSpawnPosition(itemSpawns),
                Quaternion.identity);

            yield return spawnDelayTime;
        }
    }

    private void SpawnEnemies(Transform[] enemySpawns)
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnInterval)
        {
            _elapsedTime = 0;
            if (TryGetObject(out Enemy enemy))
            {
                SetEnemy(enemy, RandomSpawnPosition(enemySpawns));
            }
        }
    }

    private IEnumerator CreateEnemies(float duration, Transform[] enemySpawns)
    {
        var spawning = true;
        var spawnDelayTime = new WaitForSeconds(duration);

        while (spawning)
        {
            if (TryGetObject(out Enemy enemy))
            {
                SetEnemy(enemy, RandomSpawnPosition(enemySpawns));
            }
           
            yield return spawnDelayTime;
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