using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    private const float _AnimationTime = 1;

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    private void Start()
    {
        Destroy(gameObject, _AnimationTime);
    }
}
