using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BulletPool), typeof(Enemy))]
public class RangeAttackState : AttackState
{
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private Bullet _template;

    [SerializeField] private int _countBullesInPool;

    private BulletPool _pool;
    private Coroutine _shootCoroutine;

    protected override void Start()
    {
        base.Start();

        _pool = GetComponent<BulletPool>();
        GetComponent<Enemy>().Dead += DestroyPool;
        _pool.Init(_template, _countBullesInPool);
    }

    protected override void Attack(Player target)
    {
        _animator.Play(_AttackAnimationTitle);
        _shootCoroutine = StartCoroutine(SpawnBulletCoroutine(target));
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

    private void DestroyPool()
    {
        _pool.DestroyPool();
    }
}
