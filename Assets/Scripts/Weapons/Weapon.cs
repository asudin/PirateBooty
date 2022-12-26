using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private float _shootingCooldown;
    [SerializeField] private bool _isUsed = false;

    [Header("Projectile")]
    [SerializeField] private float _projectileAngle;
    [SerializeField] protected Bullet Bullet;

    [Header("Effects")]
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _shootingSound;

    public AudioSource ShootingSound => _shootingSound;
    public Animator WeaponAnimator => _animator;
    public Transform ShootingPoint => _shootingPoint;
    public float ShootingCooldown => _shootingCooldown;
    public float ProjectileAngle => _projectileAngle;
    public bool IsUsed => _isUsed;

    public abstract void Shoot();
}
