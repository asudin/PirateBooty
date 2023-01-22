using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private Rigidbody2D _bulletRigidbody;
    [SerializeField] private BulletVariant _bulletVariant;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    [Header("Effects")]
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _bulletRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void DestroyBullet()
    {
        if (_bulletVariant.Type == BulletType.Shotgun)
            _bulletRigidbody.bodyType = RigidbodyType2D.Kinematic;

        var destroyTimerDelay = 0.2f;
        _speed = 0f;
        _animator.SetTrigger("isDestroyed");
        Destroy(gameObject, destroyTimerDelay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            DestroyBullet();

        if (collision.gameObject.TryGetComponent(out Wall wall) ||
            collision.gameObject.TryGetComponent(out Ground ground))
            DestroyBullet();
    }
}

[Serializable]
public class BulletVariant
{
    public BulletType Type;
}

public enum BulletType
{
    Rifle,
    Cannon,
    Shotgun
}
