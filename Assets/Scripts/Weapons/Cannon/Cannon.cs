using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class Cannon : Weapon
{
    private float _bulletAngle = 0;

    public override void Shoot()
    {
        WeaponAnimator.SetTrigger("isShooting");
        ShootingSound.Play();
        ShootBullet(_bulletAngle);
    }
}
