using UnityEngine;

public class VectorMoveBullet : Bullet
{
    private const int _barriersLayerIndex = 3;

    private Vector3 _moveDirection;

    public override void Init(Player target, GameObject shootPoint, int damage)
    {
        base.Init(target, shootPoint, damage);

        _moveDirection = (_target.transform.position - transform.position).normalized;
    }

    protected override void FlightBehavior()
    {
        transform.position += _moveDirection * Speed * Time.deltaTime;
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
