using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponConfig _weaponConfig;
    [SerializeField] private Transform _shootingPoint;


    [SerializeField] protected Bullet Bullet;

    [Header("Misc.")]
    [SerializeField] private float _shootingCooldown;

    [Header("Effects")]
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _shootingSound;

    public WeaponConfig Config => _weaponConfig;
    public AudioSource ShootingSound => _shootingSound;
    public float ShootingCooldown => _shootingCooldown;
    public Animator WeaponAnimator => _animator;
    public Transform ShootingPoint => _shootingPoint;

    public abstract void Shoot();
}
