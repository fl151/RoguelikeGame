using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Enemy))]
public class Boss : MonoBehaviour
{
    private Enemy _enemy;

    public event UnityAction Dead;

    private void OnEnable()
    {
        _enemy = GetComponent<Enemy>();
        _enemy.Dead += OnDead;
    }

    private void OnDisable()
    {
        _enemy.Dead -= OnDead;
    }

    private void OnDead()
    {
        Dead?.Invoke();
    }
}
