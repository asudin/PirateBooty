using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;

    [Header("Enemy Settings")]
    [SerializeField] private Enemy _enragedVariant;

    public EnemyData EnemyData => _enemyData;

    public event Action<Enemy, Enemy> OnChestAreaEntered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Chest>(out Chest chest))
        {
            gameObject.SetActive(false);
            OnChestAreaEntered?.Invoke(_enragedVariant, this);
        }
    }
}

