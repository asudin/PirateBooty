using UnityEngine;

public class ShotgunBullet : Bullet
{
    [SerializeField] private float destroyTimerDelay;

    private void Update()
    {
        Move();

        Destroy(gameObject, destroyTimerDelay);
    }
}
