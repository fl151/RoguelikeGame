using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Enemy))]
public class Boss : MonoBehaviour
{
    public event UnityAction Dead;

    private Enemy _enemy;

    private GameResult _gameResult;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _enemy.Dead += OnEnemyDead;

        _gameResult = FindObjectOfType<GameResult>();
        _gameResult.SetBoss(this);
    }

    private void OnEnemyDead()
    {
        Dead?.Invoke();
    }
}
