using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Crate : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<Weapon> _weapons;

    public event Action<Weapon, Crate> CollectWeapon;

    private Weapon test;

    private void Awake()
    {
        test = GetRandomWeapon(_weapons);
    }

    private void Update()
    {
        Debug.Log($"{this.name}: {test.WeaponData.Label}");
    }

    private Weapon GetRandomWeapon(List<Weapon> weapons)
    {
        return weapons[Random.Range(0, weapons.Count)];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            CollectWeapon?.Invoke(GetRandomWeapon(_weapons), this);
            Destroy(gameObject);
        }
    }
}
