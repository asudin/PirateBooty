using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/Weapon", order = 51)]
public class WeaponData : ScriptableObject
{
    [Header("Info")]
    [SerializeField] private string _label;

    [Header("Shooting")] 
    [SerializeField] private float _shootingCooldown;
    [HideInInspector]
    [SerializeField] private bool _isUsed = false;

    [Header("Projectile")]
    [SerializeField] private float _projectileAngle;
    [SerializeField] private Bullet _bullet;

    public float ShootingCooldown => _shootingCooldown;
    public float ProjectileAngle => _projectileAngle;
    public bool IsUsed => _isUsed;
    public string Label => _label;
    public Bullet Bullet => _bullet;
}
