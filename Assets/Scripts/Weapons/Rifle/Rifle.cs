public class Rifle : Weapon
{
    public override void Shoot()
    {
        WeaponAnimator.SetTrigger("isShooting");
        ShootBullet(WeaponData.ProjectileAngle);
        SoundManager.Play(SoundManager.Sounds.Rifle);
    }
}
