using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class BiggerDeathAnimation : MonoBehaviour
{
    [SerializeField] private float _scale;

    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();

        _enemy.Dead += OnDied;
    }

    private void OnDied()
    {
        _enemy.DeathEffect.transform.localScale = new Vector3(_scale, _scale, 1);
    }
}
