using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : ObjectPool<Crate>
{
    [Header("Crate Spawn Settings")]
    [SerializeField] private float _spawnInterval;
    [SerializeField] private Transform _crateSpawnPoints;
    [SerializeField] private Crate _cratePrefab;

    private Transform[] _crateSpawns;
    private float _elapsedTime;

    private void Start()
    {
        CreateSpawn(ref _crateSpawns, _crateSpawnPoints);
    }

    private void CreateSpawn(ref Transform[] spawns, Transform spawnPoints)
    {
        spawns = new Transform[spawnPoints.childCount];

        for (int i = 0; i < spawnPoints.childCount; i++)
        {
            spawns[i] = spawnPoints.GetChild(i);
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

    private void SpawnCrate(Transform[] crateSpawns)
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnInterval)
        {
            _elapsedTime = 0;
            if (TryGetObjectInPool(out Crate enemy))
            {

            }
        }
    }
}
