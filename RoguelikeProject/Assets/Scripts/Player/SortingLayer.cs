using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SortingLayer : MonoBehaviour
{
    private SpriteRenderer[] _spriteRenderers;

    private void Start()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != gameObject)
        {
            for (int i = 0; i < _spriteRenderers.Length; i++)
            {
                _spriteRenderers[i].sortingOrder = collision.GetComponent<TilemapRenderer>().sortingOrder - 1;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<Bullet>() == false)
        {
            for (int i = 0; i < _spriteRenderers.Length; i++)
            {
                _spriteRenderers[i].sortingOrder = collision.GetComponent<TilemapRenderer>().sortingOrder + 1;
            }
        }
    }
}
