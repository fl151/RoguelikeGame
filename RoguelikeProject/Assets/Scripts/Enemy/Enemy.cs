using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private GameObject _prefab;
    
    private Player _target;

    private int _currentHealth;

    public event UnityAction Damaged;

    public event UnityAction Dead;
    public Player Target => _target;

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

    public void SetTarget(Player target)
    {
        _target = target;
    }

    private void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _currentHealth -= damage;
            Damaged?.Invoke();
        }
    }

    private void Awake()
    {
        Instantiate(_prefab, gameObject.transform);
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void TryDie()
    {
        if(_currentHealth <= 0)
        {
            Dead?.Invoke();

            Destroy(gameObject);
        }
    }
}
