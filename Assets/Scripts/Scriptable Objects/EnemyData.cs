using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/Enemy", order = 51)]
public sealed class EnemyData : ScriptableObject
{
    [Header("Info"), Space]
    [SerializeField] private string _enemyName;

    [Header("Configurations"), Space]
    [field: SerializeField] public int Health;
    [field: SerializeField] public float Speed;
    [field: SerializeField] public bool IsEnraged;

    [Header("Prefab"), Space]
    [SerializeField] private GameObject _enemyPrefab;
}
