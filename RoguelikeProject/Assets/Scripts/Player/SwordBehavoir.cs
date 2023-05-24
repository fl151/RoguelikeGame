using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SwordPointDirection))]
public class SwordBehavoir : MonoBehaviour
{
    private const int EnemyLayerIndex = 6;
    private const string IdleTitle = "Idle";
    private const string SwordAttackTitle = "SwortAttack";

    private float _attackDelay;
    private int _gamage;

    private Animator _swordAnimator;
    private SwordPointDirection _swordPointDirection;

    private bool _isActive = false;
    private float _timeAfterLastAttack;

    private Collider2D[] _colliders;

    private void Start()
    {
        _swordAnimator = GetComponentInChildren<Animator>();
        _swordPointDirection = GetComponent<SwordPointDirection>();

        MakeInactive();
    }

    private void Update()
    {
        if (_isActive)
        {
            _timeAfterLastAttack += Time.deltaTime;

            if (_timeAfterLastAttack >= _attackDelay)
            {
                _timeAfterLastAttack = 0;

                Attack();
            }
        }     
    }

    private void FixedUpdate()
    {
        float range = 0.8f;
        Vector2 point = (Vector2)transform.position + _swordPointDirection.Direction.normalized * range;
        var size = new Vector2(2f, 3);
        float angle = _swordPointDirection.Angle;

        _colliders = Physics2D.OverlapBoxAll(point, size, angle, 1 << EnemyLayerIndex);

        if(_colliders.Length == 0 && _isActive)
        {
            MakeInactive();
        }
        else if(_colliders.Length != 0 && _isActive == false)
        {
            MakeActive();
        }
    }

    public void SetSettings(float delayInSeconds, int damage)
    {
        _attackDelay = delayInSeconds;
        _gamage = damage;
    }

    private void MakeInactive()
    {
        _swordAnimator.Play(IdleTitle);
        _isActive = false;
    }

    private void MakeActive()
    {
        _timeAfterLastAttack = _attackDelay;
        _isActive = true;
    }

    private void Attack()
    {
        _swordAnimator.Play(SwordAttackTitle);

        if (_colliders.Length == 0)
            return;
        else
        {
            StartCoroutine(AttackAfterDeley(0.2f));
        }
    }

    private IEnumerator AttackAfterDeley(float delay)
    {
        yield return new WaitForSeconds(delay);

        foreach (var collider in _colliders)
        {
            collider.GetComponent<Enemy>().TryApplyDamage(_gamage);
        }
    }
}
