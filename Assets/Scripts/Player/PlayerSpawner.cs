using System;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _spawnPosition;

    public bool IsPlayerInstantiated = false;

    private void Start()
    {
        ServiceLocator.Register(this);
        Spawn(_player);
    }

    public void Spawn(Player _player)
    {
        Player player = Instantiate(_player, _spawnPosition);
        Debug.Log($"Spawned player: {player}");
        ServiceLocator.Register(player);
        IsPlayerInstantiated = true;

        Debug.Log($"Registered is: {ServiceLocator.Get<Player>()}");
    }
}
