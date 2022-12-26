using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponConfig _weaponConfig;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootingPoint;

    [Header("Misc.")]
    [SerializeField] private float _shootingCooldown;

    [Header("Effects")]
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _shootingSound;

    public WeaponConfig Config => _weaponConfig;
    public AudioSource ShootingSound => _shootingSound;
    public float ShootingCooldown => _shootingCooldown;
    public Animator WeaponAnimator => _animator;

    public abstract void Shoot();

    public void ShootBullet(float shootingAngle)
    {
        Instantiate(_bullet, _shootingPoint.position, Quaternion.Euler(0f, 0f, _shootingPoint.eulerAngles.z + shootingAngle));
    }
}
