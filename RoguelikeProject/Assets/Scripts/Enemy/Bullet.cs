using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private int _damage;
    private Player _target;

    public void Init(Player target, GameObject shootPoint, int damage)
    {
        gameObject.SetActive(true);
        _target = target;

        SetDamage(damage);

        transform.position = shootPoint.transform.position;
    }

    protected virtual void FlightBehavior()
    {
        transform.position += (_target.transform.position - transform.position).normalized * _speed * Time.deltaTime;
    }

    protected virtual void HitAction(Player target)
    {
        target.ApplyDamage(_damage);
    }

    private void Update()
    {
        FlightBehavior();
    }

    private void SetDamage(int value)
    {
        if (_damage > 0)
            _damage = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _target.gameObject)
        {
            HitAction(_target);
            gameObject.SetActive(false);
        }
    }
}
