using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [Header("Pellets"), Space]
    [SerializeField] private int _pelletCount;

    public override void Shoot()
    {
        float[] rotations = new float[_pelletCount];

        for (int i = 0; i < _pelletCount; i++)
        {
            float minAngle = 15f;
            float randomAngle = Random.Range(minAngle, WeaponData.ProjectileAngle);
            float rotation = rotations[i] + randomAngle;
            WeaponAnimator.SetTrigger("isShooting");
            ShootBullet(rotation);
        }

        SoundManager.Play(SoundManager.Sounds.Pellets);
    }
}
