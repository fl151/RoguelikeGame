using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetPosition;

    private Vector3 _direction;

    private const float minRangeBetweenTarget = 0.1f;

    private void Start()
    {
        _targetPosition = new Vector3(0, 0, transform.position.z);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _targetPosition = new Vector3(mousePosition.x, mousePosition.y, _targetPosition.z);
        }

        if (_direction.magnitude > minRangeBetweenTarget)
            transform.position += _direction.normalized * Time.deltaTime * _speed;
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _direction, minRangeBetweenTarget);

        _direction = _targetPosition - transform.position;
    }
}
