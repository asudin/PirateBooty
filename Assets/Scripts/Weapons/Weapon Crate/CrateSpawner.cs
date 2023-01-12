using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class CrateSpawner : ObjectPool<Crate>
{
    [Header("Crate Spawn Settings")]
    [SerializeField] private Transform _crateSpawnPoints;
    [SerializeField] private List<Crate> _cratePrefabs;
    [SerializeField] private TMP_Text _weaponLabel;

    private Transform[] _crateSpawns;

    public event Action<Crate> Collected;

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
            spawns[i] = spawnPoints.GetChild(i);
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
        crate.SetSpawner(this);
        crate.transform.position = spawnPoint;
    }

    public void InvokeEvent(Crate crate)
    {
        Collected?.Invoke(crate);
    }
}
