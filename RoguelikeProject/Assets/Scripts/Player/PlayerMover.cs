using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _layerIndexBarriers;

    private const float MinRangeBetweenTarget = 0.1f;

    private Vector3 _targetPosition;

    private Vector3 _targetDirection;
    private Vector3 _moveDirection;

    public Vector3 MoveDirection => _moveDirection;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _targetPosition = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
        else
        {
            _targetPosition = transform.position;
        }

        transform.position += _moveDirection * Time.deltaTime * _speed;
    }

    private void FixedUpdate()
    {
        _targetDirection = _targetPosition - transform.position;

        if (_targetDirection.magnitude > MinRangeBetweenTarget)
        {
            _moveDirection = _targetDirection.normalized;

            RaycastHit2D[] hits = Physics2D.RaycastAll
                (transform.position, _targetDirection, MinRangeBetweenTarget * 2, _layerIndexBarriers);

            bool isCollider = false;

            for (int i = 0; i < hits.Length && isCollider == false; i++)
            {
                if (hits[i].collider != null && hits[i].collider.isTrigger == false)
                {
                    _moveDirection += new Vector3(hits[i].normal.x, hits[i].normal.y, 0);

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
