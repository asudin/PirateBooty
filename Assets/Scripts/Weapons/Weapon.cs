using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponConfig _weaponConfig;
    [SerializeField] private Bullet _bullet;
}
