using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : ObjectPool<Crate>
{
    [Header("Crate Spawn Settings")]
    [SerializeField] private Transform _crateSpawnPoints;
    [SerializeField] private List<Crate> _cratePrefabs;

    private Transform[] _crateSpawns;

    private void Start()
    {
        CreateSpawn(ref _crateSpawns, _crateSpawnPoints);
        Initialize(_cratePrefabs);
    }

    private void FixedUpdate()
    {
       SpawnCrate(_crateSpawns);
    }

    private void CreateSpawn(ref Transform[] spawns, Transform spawnPoints)
    {
        spawns = new Transform[spawnPoints.childCount];

        for (int i = 0; i < spawnPoints.childCount; i++)
        {
            spawns[i] = spawnPoints.GetChild(i);
        }
    }

    private void SpawnCrate(Transform[] crateSpawns)
    {
        if (TryGetObjectInPool(out Crate crate))
        {
            SetCrate(crate, RandomSpawnPosition(crateSpawns));
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

    private void SetCrate(Crate crate, Vector3 spawnPoint)
    {
        crate.gameObject.SetActive(true);
        crate.transform.position = spawnPoint;
    }
}
