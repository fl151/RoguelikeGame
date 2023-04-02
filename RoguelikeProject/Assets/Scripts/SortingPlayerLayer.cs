using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SortingPlayerLayer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _spriteRenderer.sortingOrder = collision.GetComponent<TilemapRenderer>().sortingOrder - 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _spriteRenderer.sortingOrder = collision.GetComponent<TilemapRenderer>().sortingOrder + 1;
    }
}
