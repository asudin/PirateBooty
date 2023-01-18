using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private EnemyVariant _variant;

    private EnemyCollisionHandler _collisionHandler;

    public EnemyCollisionHandler CollisionHandler => _collisionHandler;
    public EnemyData EnemyData => _enemyData;
    public EnemyVariant Variant => _variant;

    private void Awake()
    {
        _collisionHandler = GetComponent<EnemyCollisionHandler>();
    }
}

[Serializable]
public class EnemyVariant
{
    public EnemyType Type;
}

public enum EnemyType
{
    Normal,
    Enraged
}

