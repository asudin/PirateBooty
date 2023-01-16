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
            float minAngle = 10f;
            float maxAngle = WeaponData.ProjectileAngle;
            float randomAngle = Random.Range(minAngle, maxAngle);
            rotations[i] = randomAngle;
        }

        for (int i = 0; i < _pelletCount; i++)
        {
            WeaponAnimator.SetTrigger("isShooting");
            ShootBullet(rotations[i]);
        }

        SoundManager.Play(SoundManager.Sounds.Shotgun);
    }
}
