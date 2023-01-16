using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData _weaponData;

    [Header("Shooting")]
    [SerializeField] private Transform _shootingPoint;

    [Header("Effects")]
    [SerializeField] private Animator _animator;
    private SoundManager _soundManager;
    private ScreenShake _screenShake;

    public SoundManager SoundManager => _soundManager;
    public Animator WeaponAnimator => _animator;
    public WeaponData WeaponData => _weaponData;

    private void Awake()
    {
        _soundManager = ServiceLocator.Get<SoundManager>();
        _screenShake = ServiceLocator.Get<ScreenShake>();
    }

    public abstract void Shoot();

    public void ShootBullet(float shootingAngle)
    {
        Instantiate(_weaponData.Bullet, _shootingPoint.transform.position, _shootingPoint.transform.rotation * Quaternion.Euler(0f, 0f, shootingAngle));
        _screenShake.Shake(_weaponData.ShakeDuration);
    }
}
