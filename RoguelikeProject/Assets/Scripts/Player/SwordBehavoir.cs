using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SwordPointDirection))]
public class SwordBehavoir : MonoBehaviour
{
    private float _attackDelay;

    private const int _enemyLayerIndex = 6;

    private Animator _swordAnimator;
    private SwordCollider _collider;
    private SwordPointDirection _swordPointDirection;

    private bool _isActive = false;
    private float _timeAfterLastAttack;

    public event UnityAction Attacked;

    public void SetAttackDelay(float delayInSeconds)
    {
        _attackDelay = delayInSeconds;
    }

    private void Start()
    {
        _swordAnimator = GetComponentInChildren<Animator>();
        _collider = GetComponentInChildren<SwordCollider>();
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
        Vector2 point = (Vector2)transform.position + _swordPointDirection.Direction.normalized * 0.8f;
        Vector2 size = new Vector2(1.5f, 2);
        float angle = _swordPointDirection.Angle;

        Collider2D[] colliders = Physics2D.OverlapBoxAll(point, size, angle, 1 << _enemyLayerIndex);

        if(colliders.Length == 0 && _isActive)
        {
            MakeInactive();
        }
        else if(colliders.Length != 0 && _isActive == false)
        {
            MakeActive();
        }
    }

    private void MakeInactive()
    {
        _swordAnimator.Play("Idle");
        _collider.gameObject.SetActive(false);
        _isActive = false;
    }

    private void MakeActive()
    {
        _timeAfterLastAttack = _attackDelay;

        _collider.gameObject.SetActive(true);
        _isActive = true;
    }

    private void Attack()
    {
        _swordAnimator.Play("SwortAttack");

        Attacked?.Invoke();
    }
}
