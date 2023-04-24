using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _smoothing;

    private void Update()
    {
        Vector3 targetPosition = new Vector3(_target.transform.position.x, _target.transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothing * Time.deltaTime);
    }
}
