using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Bullet : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    [Header("Effects")]
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _destroySound;

    public void Move()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    public void DestroyBullet()
    {
        var destroyTimerDelay = 0.2f;

        //_animator.SetTrigger("isDestroyed");
        Destroy(gameObject, destroyTimerDelay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Debug.Log($"enemy");
            _destroySound.Play();
            DestroyBullet();
        }

        if (collision.gameObject.TryGetComponent(out Wall wall) ||
            collision.gameObject.TryGetComponent(out Ground ground))
        {
            Debug.Log($"wall");
            _destroySound.Play();
            DestroyBullet();
        }
    }
}
