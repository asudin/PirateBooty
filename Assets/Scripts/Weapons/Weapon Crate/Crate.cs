using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Crate : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<Weapon> _weapons;

    private Weapon randomWeapon;

    public event Action<Weapon> CollectWeapon;

    private void Awake()
    {
        randomWeapon = GetRandomWeapon(_weapons);
    }

    private Weapon GetRandomWeapon(List<Weapon> weapons)
    {
        return weapons[Random.Range(0, weapons.Count)];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            CollectWeapon?.Invoke(randomWeapon);
            Destroy(gameObject);
        }
    }
}
