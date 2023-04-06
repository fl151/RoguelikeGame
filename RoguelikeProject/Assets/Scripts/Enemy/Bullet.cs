using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private int _damage;
    private Player _target;

    public void Init(Player target, GameObject shootPoint)
    {
        gameObject.SetActive(true);
        _target = target;
        transform.position = shootPoint.transform.position;
    }

    public void SetDamage(int value)
    {
        if (_damage > 0)
            _damage = value;
    }

    private void Update()
    {
        transform.position += (_target.transform.position - transform.position).normalized * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _target.gameObject)
        {
            _target.ApplyDamage(_damage);
            gameObject.SetActive(false);
        }
    }
}
