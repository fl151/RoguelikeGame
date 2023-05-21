using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SwordPointDirection))]
public class SwordBehavoir : MonoBehaviour
{
    private float _attackDelay;
    private int _gamage;

    private const int _enemyLayerIndex = 6;

    private Animator _swordAnimator;
    private SwordPointDirection _swordPointDirection;

    private bool _isActive = false;
    private float _timeAfterLastAttack;

    private Collider2D[] _colliders;

    public void SetSettings(float delayInSeconds, int damage)
    {
        _attackDelay = delayInSeconds;
        _gamage = damage;
    }

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

        _colliders = Physics2D.OverlapBoxAll(point, size, angle, 1 << _enemyLayerIndex);

        if(_colliders.Length == 0 && _isActive)
        {
            MakeInactive();
        }
        else if(_colliders.Length != 0 && _isActive == false)
        {
            MakeActive();
        }
    }

    private void MakeInactive()
    {
        _swordAnimator.Play("Idle");
        _isActive = false;
    }

    private void MakeActive()
    {
        _timeAfterLastAttack = _attackDelay;
        _isActive = true;
    }

    private void Attack()
    {
        _swordAnimator.Play("SwortAttack");

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
