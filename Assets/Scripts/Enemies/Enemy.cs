using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;

    private EnemyCollisionHandler _collisionHandler;

    public EnemyCollisionHandler CollisionHandler => _collisionHandler;
    public EnemyData EnemyData => _enemyData;

    private void Awake()
    {
        _collisionHandler = GetComponent<EnemyCollisionHandler>();
    }
}

