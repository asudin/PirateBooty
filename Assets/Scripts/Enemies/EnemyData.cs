using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName ="Source/Enemy", order = 51)]
public sealed class EnemyData : ScriptableObject
{
    [Header("[Name]"), Space]
    [SerializeField] private string _enemyName;

    [Header("[Stats]"), Space]
    [field: SerializeField] public int Health;
    [field: SerializeField] public float Speed;
    [field: SerializeField] public bool IsEnraged;

    [Header("[Prefab]"), Space]
    [SerializeField] private GameObject _enemyPrefab;
}
