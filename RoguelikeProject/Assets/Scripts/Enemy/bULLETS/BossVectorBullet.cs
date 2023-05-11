using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVectorBullet : Bullet
{
    private const int _barriersLayerIndex = 3;

    private Vector3 _direction;

    public void Init(Vector3 direction, int damage, GameObject shootPoint)
    {
        gameObject.SetActive(true);

        Damage = damage;
        _direction = direction;

        transform.position = shootPoint.transform.position;
    }

    protected override void FlightBehavior()
    {
        transform.position += _direction.normalized * Speed * Time.deltaTime;
    }

    protected override void HitBehavior(Collider2D collision)
    {
        if (collision.gameObject.layer == _barriersLayerIndex)
        {
            gameObject.SetActive(false);

            return;
        }

        if (collision.gameObject == Target.gameObject)
        {
            Target.ApplyDamage(Damage);
            gameObject.SetActive(false);

            return;
        }
    }  
}
