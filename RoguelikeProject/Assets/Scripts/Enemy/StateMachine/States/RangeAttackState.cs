using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletPool))]
public class RangeAttackState : AttackState
{
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private Bullet _template;

    [SerializeField] private int _countBullesInPool;

    private BulletPool _pool;
    private Coroutine _shootCoroutine;

    protected override void Attack(Player target)
    {
        _animator.Play("attack");

        _shootCoroutine = StartCoroutine(SpawnBulletCoroutine(target));
    }

    protected override void Start()
    {
        base.Start();

        _pool = GetComponent<BulletPool>();
        _pool.Init(_template, _countBullesInPool);
    }

    private IEnumerator SpawnBulletCoroutine(Player target)
    {
        yield return new WaitForSeconds(0.2f);

        if(_pool.TryGetBullet(out Bullet bullet))
        {
            bullet.Init(target, _shootPoint, _damage);
        }

        StopCoroutine(_shootCoroutine);
    }
}
