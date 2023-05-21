using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _target;
    
    private SpawnPoint[] _spawnPoints;

    public void SpawnEnemy(Enemy prefab)
    {
        int indexSpawnPoint = Random.Range(0, _spawnPoints.Length);
        Enemy enemy = Instantiate(prefab, _spawnPoints[indexSpawnPoint].transform);

        enemy.SetTarget(_target);
    }

    public void SpawnEnemy(Enemy prefab, int indexSpawnPoint)
    {
        if (_spawnPoints.Length > indexSpawnPoint && 0 <= indexSpawnPoint)
        {
            Enemy enemy = Instantiate(prefab, _spawnPoints[indexSpawnPoint].transform);
            enemy.SetTarget(_target);

            if (_spawnPoints[indexSpawnPoint] == null)
                Debug.LogWarning("точки спавна с таким индексом не существует");
        }
        else
        {
            Debug.LogError("Неверный индекс точки спавна!");
        }
    }

    public void SpawnEnemy(Enemy prefab, int[] indexesSpawnPoints)
    {
        int indexSpawnPoint = Random.Range(0, indexesSpawnPoints.Length);

        prefab.SetTarget(_target);

        Instantiate(prefab, _spawnPoints[indexesSpawnPoints[indexSpawnPoint]].transform);    
    }

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }
}
