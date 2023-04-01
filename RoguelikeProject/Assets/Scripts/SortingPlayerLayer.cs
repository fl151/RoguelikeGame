using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingPlayerLayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, collision.transform.position.z - 0.1f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, collision.transform.position.z + 0.1f);
    }
}
