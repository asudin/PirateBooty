using System;
using System.Collections;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    [SerializeField] private Enemy _enragedVariant;

    private CapsuleCollider2D _enemyCollider;
    private Enemy _enemy;
    private SoundManager _soundManager;

    public event Action<Enemy, Enemy> OnChestAreaEntered;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _enemyCollider = GetComponent<CapsuleCollider2D>();
        _soundManager = ServiceLocator.Get<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Chest chest))
        {
            gameObject.SetActive(false);
            _soundManager.Play(SoundManager.Sounds.ChestReached);
            OnChestAreaEntered?.Invoke(_enragedVariant, _enemy);
        }

        if (collision.TryGetComponent(out Bullet bullet))
        {
            _soundManager.Play(SoundManager.Sounds.EnemyHit);
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Crate crate))
        {
            Physics2D.IgnoreCollision(_enemyCollider, crate.Collider, true);
        } 
    }
}
