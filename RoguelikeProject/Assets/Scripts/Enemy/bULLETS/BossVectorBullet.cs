using UnityEngine;

public class BossVectorBullet : Bullet
{
    private const int _barriersLayerIndex = 3;

    private Vector3 _direction;

    public void Init(Player target, Vector3 direction, int damage, GameObject shootPoint)
    {
        gameObject.SetActive(true);

        _damage = damage;
        _direction = direction;
        _target = target;

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

        if (collision.gameObject == _target.gameObject)
        {
            _target.ApplyDamage(_damage);
            gameObject.SetActive(false);

            return;
        }
    }  
}
