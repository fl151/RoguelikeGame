using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DamageIndicator : MonoBehaviour
{
    private WaitForSeconds _IndicateTime = new WaitForSeconds(0.2f);

    private Enemy _enemy;
    private SpriteRenderer[] _spriteRenderers;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        _enemy.Damaged += Indicate;
    }

    private void Indicate()
    {
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        foreach (var spriteRenderer in _spriteRenderers)
        {
            spriteRenderer.color = Color.red;
        }

        yield return _IndicateTime;

        foreach (var spriteRenderer in _spriteRenderers)
        {
            spriteRenderer.color = Color.white;
        }
    }
}
