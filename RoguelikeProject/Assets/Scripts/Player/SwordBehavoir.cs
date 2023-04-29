using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SwordPointDirection))]
public class SwordBehavoir : MonoBehaviour
{
    private const int _enemyLayerIndex = 6;

    private Animator _swordAnimator;
    private SwordCollider _collider;
    private SwordPointDirection _swordPointDirection;

    private bool _isActive = false;


    private void Start()
    {
        _swordAnimator = GetComponentInChildren<Animator>();
        _collider = GetComponentInChildren<SwordCollider>();
        _swordPointDirection = GetComponent<SwordPointDirection>();

        MakeInacite();
    }

    private void FixedUpdate()
    {
        Vector2 point = (Vector2)transform.position + _swordPointDirection.Direction.normalized * 0.8f;
        Vector2 size = new Vector2(1.5f, 2);
        float angle = _swordPointDirection.Angle;

        Collider2D[] colliders = Physics2D.OverlapBoxAll(point, size, angle, 1 << _enemyLayerIndex);

        if(colliders.Length == 0 && _isActive)
        {
            MakeInacite();
        }
        else if(colliders.Length != 0 && _isActive == false)
        {
            MakeActive();
        }
    }

    private void MakeInacite()
    {
        _swordAnimator.Play("Idle");
        _collider.gameObject.SetActive(false);
        _isActive = false;
    }

    private void MakeActive()
    {
        _swordAnimator.Play("SwortAttack");
        _collider.gameObject.SetActive(true);
        _isActive = true;
    }
}
