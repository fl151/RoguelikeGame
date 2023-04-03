using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    [SerializeField] private float _speed;

    private Vector3 _targetDirection;
    private Vector3 _moveDirection;

    private const float _minRangeBetweenTarget = 0.1f;

    private float _zPosition;


    private void Start()
    {
        _zPosition = transform.position.z;
    }

    private void Update()
    {
        transform.position += _moveDirection * Time.deltaTime * _speed;
    }

    private void FixedUpdate()
    {
        _targetDirection = Target.transform.position - transform.position;

        if (_targetDirection.magnitude > _minRangeBetweenTarget)
        {
            _moveDirection = _targetDirection.normalized;

            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, _targetDirection, _minRangeBetweenTarget);

            if (hits.Length > 1)
            {
                bool isCollider = false;

                for (int i = 1; i < hits.Length; i++)
                {
                    if (hits[i].collider != null && hits[i].collider.isTrigger == false)
                    {
                        _moveDirection = new Vector3(hits[i].normal.x, hits[i].normal.y, _zPosition) + _targetDirection.normalized;

                        isCollider = true;
                    }

                    if (isCollider)
                        break;
                }
            }
        }
        else
        {
            _moveDirection = _targetDirection;
        }
    }
}
