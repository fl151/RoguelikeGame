using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    private const float _AnimationTime = 1;

    private float _playTime;
    private float _currentTime;

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    private void Start()
    {
        _playTime = _AnimationTime;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _playTime)
            Destroy(gameObject);
    }
}
