using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private GameResult _gameResult;
    
    [SerializeField] private SpawnPoint[] _spawnPoints;

    public void SpawnEnemy(Enemy prefab, int[] indexesSpawnPoints)
    {
        int indexSpawnPoint;

        indexSpawnPoint = Random.Range(0, indexesSpawnPoints.Length);

        InitEnemy(prefab, indexesSpawnPoints[indexSpawnPoint]);
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
