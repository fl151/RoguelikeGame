using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDelay;

    private int _currentHealth;

    public event UnityAction Died;

    public void ApplyDamage(int damage)
    {
        if (damage > 0)
        {
            _currentHealth -= damage;


            if (_currentHealth <= 0)
                Die();
        }
    }

    private void Start()
    {
        Respawn();

        GetComponentInChildren<SwordBehavoir>().SetAttackDelay(_attackDelay);
    }

    private void Die()
    {
        Died?.Invoke();

        gameObject.SetActive(false);
    }

    private void Respawn()
    {
        gameObject.SetActive(true);
        _currentHealth = _maxHealth;
    }
}
