using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Config", fileName = "WeaponConfig", order = 51)]
public class WeaponConfig : ScriptableObject
{
    [Header("Name")]
    [SerializeField] private string _weaponLabel;

    [Header("Configurations")]
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isUsed = false;

    public string WeaponLabel => _weaponLabel;
    public bool IsUsed => _isUsed;
}
