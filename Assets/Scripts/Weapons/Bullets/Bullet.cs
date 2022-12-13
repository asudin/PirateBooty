using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Bullet : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    [Header("Effects")]
    [SerializeField] private Animator _animator;

    public void Move()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    public void DestroyBullet()
    {
        var destroyTimerDelay = 0.2f;

        _animator.SetTrigger("isDestroyed");
        Destroy(gameObject, destroyTimerDelay);
    }
}
