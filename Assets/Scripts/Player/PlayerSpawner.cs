using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _spawnPosition;

    private void Start()
    {
        Spawn(_player);
    }

    private void Update()
    {
        if (_player.IsAlive == false)
            Spawn(_player);
    }

    private void Spawn(Player _player)
    {
        Instantiate(_player, _spawnPosition);
    }
}
