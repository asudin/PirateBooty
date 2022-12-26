using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class Cannon : Weapon
{
    public override void Shoot()
    {
        WeaponAnimator.SetTrigger("isShooting");
        ShootingSound.Play();
        Instantiate(Bullet, ShootingPoint.position, transform.rotation);
    }
}
