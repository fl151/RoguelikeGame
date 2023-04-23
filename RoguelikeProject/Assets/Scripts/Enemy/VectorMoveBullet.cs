
using UnityEngine;

public class VectorMoveBullet : Bullet
{
    private const int enemyLayerIndex = 6;

    private Vector3 _moveDirection;

    private bool _isDirectionFinded = false;

    public override void Init(Player target, GameObject shootPoint, int damage)
    {
        base.Init(target, shootPoint, damage);

        _moveDirection = (Target.transform.position - transform.position).normalized;
    }

    protected override void FlightBehavior()
    {
        transform.position += _moveDirection * Speed * Time.deltaTime;
    }

    protected override void HitBehavior(Collider2D collision)
    {
        Debug.Log(collision);

        if (collision.gameObject.layer == 3)
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
