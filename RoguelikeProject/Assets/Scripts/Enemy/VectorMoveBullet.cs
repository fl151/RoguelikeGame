
using UnityEngine;

public class VectorMoveBullet : Bullet
{
    private const int enemyLayerIndex = 6;

    private Vector3 _moveDirection;

    private bool _isDirectionFinded = false;

    protected override void FlightBehavior()
    {
        if (_isDirectionFinded == false)
        {
            _moveDirection = (Target.transform.position - transform.position).normalized;
            _isDirectionFinded = true;
        }
        else
        {
            transform.position += _moveDirection * Speed * Time.deltaTime;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false && collision.gameObject.layer != enemyLayerIndex)
        {
            if (collision.gameObject == Target.gameObject)
                Target.ApplyDamage(Damage);

            Debug.Log(collision);

            gameObject.SetActive(false);
        }
    }
}
