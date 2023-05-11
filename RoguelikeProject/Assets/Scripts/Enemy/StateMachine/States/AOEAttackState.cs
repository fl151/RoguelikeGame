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

    private Coroutine _processCoroutine;

    private void Start()
    {
        InitPool();
    }

    private void OnEnable()
    {
        if (_processCoroutine != null)
        {
            StopCoroutine(_processCoroutine);         
        }

        _processCoroutine = StartCoroutine(Process());
    }

    private IEnumerator Process()
    {
        while (true)
        {
            for(int i = 0; i < _attackTypes.Length; i++)
            {
                BossAttackType type = _attackTypes[i];
                var delay = new WaitForSeconds(type.Delay);

                for(int j = 0; j < type.Times; j++)
                {
                    Attack(type);

                    yield return delay;
                }

                yield return new WaitForSeconds(type.DelayAfter);
            }
        }
    }

    private void Attack(BossAttackType type)
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
