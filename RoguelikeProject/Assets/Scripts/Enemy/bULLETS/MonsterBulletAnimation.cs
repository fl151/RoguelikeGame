using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MonsterBulletAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("move");
    }
}
