using System;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _spawnPosition;

    private void Start()
    {
        //ServiceLocator.Register(this);
        Spawn(_player);
    }

    public void Spawn(Player player)
    {
        ResetPlayer(player);
        player.Spawn();
    }

    public void ResetPlayer(Player player)
    {
        player.transform.position = _spawnPosition.transform.position;
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
