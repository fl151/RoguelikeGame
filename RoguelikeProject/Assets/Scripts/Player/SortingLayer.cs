using UnityEngine;
using UnityEngine.Tilemaps;

public class SortingLayer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() == false && collision.GetComponent<Player>() == false)
            _spriteRenderer.sortingOrder = collision.GetComponent<TilemapRenderer>().sortingOrder - 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() == false && collision.GetComponent<Player>() == false)
            _spriteRenderer.sortingOrder = collision.GetComponent<TilemapRenderer>().sortingOrder + 1;
    }
}
