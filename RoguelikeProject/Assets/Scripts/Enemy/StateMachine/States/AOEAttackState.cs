using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy), typeof(BulletPool))]
public class AOEAttackState : State
{
    [SerializeField] private Bullet _template;
    [SerializeField] private int _countBulletsInPool;

    [SerializeField] private BossAttackType[] _attackTypes;

    private BulletPool _pool;

    private void Start()
    {
        InitPool();
    }

    private void OnEnable()
    {
        
    }


    private void InitPool()
    {
        _pool = GetComponent<BulletPool>();
        GetComponent<Enemy>().Dead += DestroyPool;
        _pool.Init(_template, _countBulletsInPool);
    }

    private void DestroyPool()
    {
        _pool.DestroyPool();
    }
}
