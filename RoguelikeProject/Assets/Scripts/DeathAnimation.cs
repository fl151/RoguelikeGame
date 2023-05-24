using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    private const float AnimationTime = 1;

    private void Start()
    {
        Destroy(gameObject, AnimationTime);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    } 
}
