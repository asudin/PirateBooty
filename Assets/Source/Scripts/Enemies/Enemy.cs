using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;

    public EnemyData EnemyData => _enemyData;
}

