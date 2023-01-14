using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _spawnPosition;

    private void Start()
    {
        ServiceLocator.Register(this);
        Spawn(_player);
    }

    public void Spawn(Player _player)
    {
        Instantiate(_player, _spawnPosition);
    }
}
