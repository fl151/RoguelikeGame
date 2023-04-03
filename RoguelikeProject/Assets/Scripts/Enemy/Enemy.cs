using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public bool IsDied { get; private set; }
    public Player Target => _target;

    private void Start()
    {
        _currentHealth = _maxHealth;
        IsDied = false;
    }

    public void TryApplyDamage(int damage)
    {
        TakeDamage(damage);

        TryDie();
    }

    public void TakeHeal(int heal)
    {
        if (heal > 0)
        {
            _currentHealth += heal;
        }
    }

    protected virtual void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _currentHealth -= damage;
        }
    }

    private void TryDie()
    {
        if(_currentHealth <= 0)
        {
            IsDied = true;
        }
    }
}
