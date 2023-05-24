using UnityEngine;

public class WalkState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _layerIndexBarriers;

    private const float _MinRangeBetweenTarget = 0.1f;

    private Vector3 _targetDirection;
    private Vector3 _moveDirection;

    private void Update()
    {
        transform.position += _moveDirection * Time.deltaTime * _speed;
    }

    private void FixedUpdate()
    {
        _targetDirection = Target.transform.position - transform.position;

        if (_targetDirection.magnitude > _MinRangeBetweenTarget)
        {
            _moveDirection = _targetDirection.normalized;

            RaycastHit2D[] hits = Physics2D.RaycastAll
                (transform.position, _targetDirection, _MinRangeBetweenTarget * 2, _layerIndexBarriers);

            bool isCollider = false;

            for (int i = 0; i < hits.Length && isCollider == false; i++)
            {
                if (hits[i].collider != null && hits[i].collider.isTrigger == false)
                {
                    _moveDirection = new Vector3(hits[i].normal.x, hits[i].normal.y, 0) + _targetDirection.normalized;

                    isCollider = true;
                }
            }
        }
        else
        {
            _moveDirection = _targetDirection;
        }
    }
}
