using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Coin _coinPrefab;

    private Transform[] _spawns;

    private void Start()
    {
        _spawns = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _spawns[i] = _spawnPoints.GetChild(i);
        }

        SpawnCoins();
    }

    private void SpawnCoins()
    {
        var spawningInterval = 4f;

        StartCoroutine(CreateCoins(spawningInterval));
    }

    private IEnumerator CreateCoins(float duration)
    {
        var spawning = true;
        var spawnDelayTime = new WaitForSeconds(duration);

        while (spawning)
        {
            var randomSpawn = Random.Range(0, _spawns.Length);
            var spawnPosition = new Vector3(_spawns[randomSpawn].transform.position.x, _spawns[randomSpawn].transform.position.y);

            Coin newCoin = Instantiate(_coinPrefab, spawnPosition, Quaternion.identity);
            yield return spawnDelayTime;
        }
    }
}