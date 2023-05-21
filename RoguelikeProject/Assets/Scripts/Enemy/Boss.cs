using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Enemy))]
public class Boss : MonoBehaviour
{
    private Enemy _enemy;
    private GameResult _gameResult;

    public event UnityAction Dead;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _enemy.Dead += OnDead;

        _gameResult = FindObjectOfType<GameResult>();
        _gameResult.SetBoss(this);
    }

    private void OnDead()
    {
        Dead?.Invoke();
    }
}
