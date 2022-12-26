using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Config", fileName = "WeaponConfig", order = 51)]
public class WeaponConfig : ScriptableObject
{
    [Header("Name")]
    [SerializeField] private string _weaponLabel;


    public string WeaponLabel => _weaponLabel;
}
