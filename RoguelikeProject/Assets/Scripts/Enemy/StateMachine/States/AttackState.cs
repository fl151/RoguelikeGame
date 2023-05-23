using System.Collections; 
using UnityEngine;

[RequireComponent(typeof(EnemyStateMachine))]
public class AttackState : State
{
    [SerializeField] protected int _damage;
    [SerializeField] private float _delay;

    protected const string _AttackAnimationTitle = "attack";

    protected Animator _animator;
    private Coroutine _attackCorutine;
    private EnemyStateMachine _machine;

    protected virtual void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _machine = GetComponent<EnemyStateMachine>();
    }

    protected virtual void Attack(Player target)
    {
        _animator.Play(_AttackAnimationTitle);
        target.ApplyDamage(_damage);
    }

    private void Update()
    {
        if (_attackCorutine != null)
            return;

        _attackCorutine = StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        _machine.StopTransits();

        Attack(Target);

        yield return new WaitForSeconds(_delay);

        _machine.StartTransits();

        StopCoroutine(_attackCorutine);
        _attackCorutine = null;
    }
}
