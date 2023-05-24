using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float Speed;

    protected Player _target;
    protected int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitBehavior(collision);
    }

    private void Update()
    {
        FlightBehavior();
    }

    public virtual void Init(Player target, GameObject shootPoint, int damage)
    {
        gameObject.SetActive(true);
        _target = target;

        _damage = damage;

        transform.position = shootPoint.transform.position;
    }

    protected virtual void FlightBehavior()
    {
        transform.position += (_target.transform.position - transform.position).normalized * Speed * Time.deltaTime;
    }

    protected virtual void HitBehavior(Collider2D collision)
    {
        if (collision.gameObject == _target.gameObject)
        {
            _target.ApplyDamage(_damage);
            gameObject.SetActive(false);
        }
    }
}
