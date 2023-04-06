using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetPosition;

    private Vector3 _targetDirection;
    private Vector3 _moveDirection;
    private Player _player;

    private const float _minRangeBetweenTarget = 0.1f;

    private void Start()
    {
        _player = GetComponent<Player>();
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _targetPosition = new Vector3(mousePosition.x, mousePosition.y, 0);
        }

        transform.position += _moveDirection * Time.deltaTime * _speed;
    }

    private void FixedUpdate()
    {
        _targetDirection = _targetPosition - transform.position;

        if (_targetDirection.magnitude > _minRangeBetweenTarget)
        {
            _moveDirection = _targetDirection.normalized;

            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, _targetDirection, _minRangeBetweenTarget * 2);

            bool isCollider = false;

            for (int i = 0; i < hits.Length; i++)
            {
                if (IsCorrectHit(hits[i]))
                {
                    _moveDirection += new Vector3(hits[i].normal.x, hits[i].normal.y, 0);

                    isCollider = true;
                }

                if (isCollider)
                    break;
            }
        }
        else
        {
            _moveDirection = _targetDirection;
        }
    }

    private bool IsCorrectHit(RaycastHit2D hit)
    {
        return hit.transform.gameObject != gameObject && hit.transform.GetComponent<Enemy>() == false && hit.collider != null && hit.collider.isTrigger == false;
    }
}
