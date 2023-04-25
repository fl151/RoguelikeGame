using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class WeveChanger : MonoBehaviour
{
    [SerializeField] private Wave[] _waves;

    private Spawner _spawner;

    private void Start()
    {
        _spawner = GetComponent<Spawner>();
    }

    private void InitWave(Wave wave)
    {

    }
}
