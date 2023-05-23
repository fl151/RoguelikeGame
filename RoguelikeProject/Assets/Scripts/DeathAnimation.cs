using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    private const float _AnimationTime = 1;

    private void Start()
    {
        Destroy(gameObject, _AnimationTime);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    } 
}
