using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DamageIndicator : MonoBehaviour
{
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _enemy.Damaged += Indicate;
    }

    private void Indicate()
    {
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        foreach (var spriteRenderer in spriteRenderers)
        {
            spriteRenderer.color = Color.red;
        }

        yield return new WaitForSeconds(0.1f);

        foreach (var spriteRenderer in spriteRenderers)
        {
            spriteRenderer.color = Color.white;
        }
    }
}
