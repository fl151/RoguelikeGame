using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private GameResult _gameResult;
    
    [SerializeField] private SpawnPoint[] _spawnPoints;

    public void SpawnEnemy(Enemy prefab)
    {
        int indexSpawnPoint = Random.Range(0, _spawnPoints.Length);

        InitEnemy(prefab, indexSpawnPoint);
    }

    public void SpawnEnemy(Enemy prefab, int indexSpawnPoint)
    {
        if (_spawnPoints.Length > indexSpawnPoint && 0 <= indexSpawnPoint)
        {
            InitEnemy(prefab, indexSpawnPoint);

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
        int indexSpawnPoint;

        if (indexesSpawnPoints.Length == 1)
            indexSpawnPoint = indexesSpawnPoints[0];
        else
            indexSpawnPoint = Random.Range(0, indexesSpawnPoints.Length);

        InitEnemy(prefab, indexSpawnPoint);
    }

    private void InitEnemy(Enemy prefab, int indexSpawnPoint)
    {
        var enemy = Instantiate(prefab, _spawnPoints[indexSpawnPoint].transform);

        enemy.SetTarget(_target);

        if (enemy.TryGetComponent(out Boss boss))
        {
            _gameResult.SetBoss(boss);
        }
    }
}
