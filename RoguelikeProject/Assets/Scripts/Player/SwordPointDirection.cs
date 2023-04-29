using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPointDirection : MonoBehaviour
{
    private PlayerMover _playerMover;

    private float _angle;

    public float Angle => _angle;

    public Vector2 Direction { get; private set; }

    private void Start()
    {
        _playerMover = FindObjectOfType<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _angle = Vector2.SignedAngle(Vector2.right, _playerMover.MoveDirection);
            Direction = _playerMover.MoveDirection;
        }

        transform.eulerAngles = new Vector3(0, 0, _angle + 45);
    }
}
