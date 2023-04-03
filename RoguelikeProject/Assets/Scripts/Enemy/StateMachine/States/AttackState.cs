using System.Collections; 
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(EnemyStateMachine))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private Animator _animator;

    private Coroutine _attackCorutine;

    private EnemyStateMachine _machine;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();

        _machine = GetComponent<EnemyStateMachine>();
    }

    private void Update()
    {
        if (_attackCorutine == null)
            return;

        StartCoroutine(AttackCoroutine());
    }

    private void Attack(Player target)
    {
        _animator.Play("Attack");
        target.ApplyDamage(_damage);
    }

    private IEnumerator AttackCoroutine()
    {
        _machine.StopTransits();

        yield return new WaitForSeconds(_delay / 2);

        Attack(Target);

        yield return new WaitForSeconds(_delay / 2);

        StopCoroutine(_attackCorutine);

        _machine.StartTransits();
    }
}
