using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy), typeof(BulletPool))]
public class AOEAttackState : State
{
    [SerializeField] private Bullet _template;
    [SerializeField] private int _damage;
    [SerializeField] private int _countBulletsInPool;

    [SerializeField] private BossAttackType[] _attackTypes;

    private BulletPool _pool;

    private Coroutine _processCoroutine;

    private void Start()
    {
        InitPool();

        _processCoroutine = StartCoroutine(Process());
    }

    private void OnDisable()
    {
        StopCoroutine(_processCoroutine);

        _processCoroutine = null;
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
                    Attack(type.Count, type.Angle, j);

                    yield return delay;
                }

                yield return new WaitForSeconds(type.DelayAfter);
            }
        }
    }

    private void Attack(int countBullets, float angleChangeByTime, int time)
    {
        float angleBetweenBullets = 360 / countBullets;

        for(int i = 0; i < countBullets; ++i)
        {
            float angle = angleBetweenBullets * i + angleChangeByTime * time;

            if (_pool.TryGetBullet(out Bullet bullet))
            {
                var bulletCurrentType = bullet as BossVectorBullet;

                bulletCurrentType.Init(Target, GetDirection(angle), _damage, transform.gameObject);
            }  
        }
    }

    private Vector3 GetDirection(float angle)
    {
        var directionX = new Vector3(Mathf.Cos(GetAngleInRad(angle)), 0, 0);
        var directionY = new Vector3(0, Mathf.Sin(GetAngleInRad(angle)), 0);

        return directionX + directionY;
    }

    private float GetAngleInRad(float angleInDegrees)
    {
        return angleInDegrees * Mathf.PI / 180;
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
