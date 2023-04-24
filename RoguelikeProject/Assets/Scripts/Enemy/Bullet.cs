using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float Speed;

    protected Player Target;

    protected int Damage;

    public virtual void Init(Player target, GameObject shootPoint, int damage)
    {
        gameObject.SetActive(true);
        Target = target;

        Damage = damage;

        transform.position = shootPoint.transform.position;
    }

    protected virtual void FlightBehavior()
    {
        transform.position += (Target.transform.position - transform.position).normalized * Speed * Time.deltaTime;

        Debug.Log((Target.transform.position - transform.position).normalized);
    }

    protected virtual void HitBehavior(Collider2D collision)
    {
        if (collision.gameObject == Target.gameObject)
        {
            Target.ApplyDamage(Damage);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitBehavior(collision);
    }

    private void Update()
    {
        FlightBehavior();
    }
}
