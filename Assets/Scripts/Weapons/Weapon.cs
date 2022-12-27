using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData _weaponData;

    [Header("Shooting")]
    [SerializeField] private Transform _shootingPoint;

    [Header("Effects")]
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _shootingSound;

    public AudioSource ShootingSound => _shootingSound;
    public Animator WeaponAnimator => _animator;
    public WeaponData WeaponData => _weaponData;

    public void Shoot()
    {
        WeaponAnimator.SetTrigger("isShooting");
        ShootingSound.Play();
        Instantiate(_weaponData.Bullet, _shootingPoint.transform.position, transform.rotation);
    }
}
