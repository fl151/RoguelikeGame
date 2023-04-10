using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float Speed;

    protected Player Target;

    protected int Damage;

    public void Init(Player target, GameObject shootPoint, int damage)
    {
        gameObject.SetActive(true);
        Target = target;

        SetDamage(damage);

        transform.position = shootPoint.transform.position;
    }

    protected virtual void FlightBehavior()
    {
        transform.position += (Target.transform.position - transform.position).normalized * Speed * Time.deltaTime;

        Debug.Log((Target.transform.position - transform.position).normalized);
    }

    private void Update()
    {
        FlightBehavior();
    }

    private void SetDamage(int value)
    {
        if (Damage > 0)
            Damage = value;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Target.gameObject)
        {
            Target.ApplyDamage(Damage);
            gameObject.SetActive(false);
        }
    }
}
