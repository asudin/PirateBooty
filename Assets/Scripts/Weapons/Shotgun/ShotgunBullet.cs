using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShotgunBullet : Bullet
{
    [SerializeField] private float destroyTimerDelay;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();

        Destroy(gameObject, destroyTimerDelay);
    }
}
