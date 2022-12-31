using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [Header("Configurations")]
    //private int _playerScore = 0;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _dieSound;

    [Header("Weapons")]
    [SerializeField] private Transform _weaponParent;
    private Weapon[] _weapons;

    private float _lastShotTime;
    private Weapon _currentWeapon;

    public Weapon CurrentWeapon => _currentWeapon;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _dieSound = GetComponent<AudioSource>();

        _weapons = _weaponParent.GetComponentsInChildren<Weapon>(true);
        _currentWeapon = _weapons[0];
    }

    private void Update()
    {
        Shoot();
    }

    private void ChangeWeapon(int randomWeaponIndex)
    {
        _currentWeapon.gameObject.SetActive(false);
        _currentWeapon = _weapons[randomWeaponIndex];
        _currentWeapon.gameObject.SetActive(true);
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.X))
            if (_lastShotTime <= 0)
            {
                _currentWeapon.Shoot();
                _lastShotTime = _currentWeapon.WeaponData.ShootingCooldown;
            }
        _lastShotTime -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.TryGetComponent(out Crate crate))
        {
            ChangeWeapon(crate.GetRandomWeaponIndex());
            Destroy(crate.gameObject);
        }
    }
}