using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    private float _playTime;

    private float _currentTime;

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    private void Start()
    {
        _playTime = 1;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _playTime)
            Destroy(gameObject);
    }
}
