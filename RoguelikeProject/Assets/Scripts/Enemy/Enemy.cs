using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private int _maxHealth;
    [SerializeField] private GameObject _prefab;

    private int _currentHealth;

    public bool IsDied { get; private set; }
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

    private void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _currentHealth -= damage;
        }
    }

    private void Awake()
    {
        Instantiate(_prefab, gameObject.transform);
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        IsDied = false;
    }

    private void TryDie()
    {
        if(_currentHealth <= 0)
        {
            IsDied = true;
        }
    }
}
