using UnityEngine;

public class Spawner : MonoBehaviour
{
    private SpawnPoint[] _spawnPoints;

    public void SpawnEnemy(Enemy prefab)
    {
        int indexSpawnPoint = Random.Range(0, _spawnPoints.Length);

        Instantiate(prefab, _spawnPoints[indexSpawnPoint].transform);
    }

    public void SpawnEnemy(Enemy prefab, int indexSpawnPoint)
    {
        if (_spawnPoints.Length > indexSpawnPoint && 0 <= indexSpawnPoint)
        {
            Instantiate(prefab, _spawnPoints[indexSpawnPoint].transform);

            if (_spawnPoints[indexSpawnPoint] == null)
                Debug.LogWarning("����� ������ � ����� �������� �� ����������");
        }
        else
        {
            Debug.LogError("�������� ������ ����� ������!");
        }
    }

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }
}
