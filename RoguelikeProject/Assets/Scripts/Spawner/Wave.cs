using UnityEngine;

[CreateAssetMenu(fileName = "Wave",menuName = "Wave", order = 52)]
public class Wave : ScriptableObject
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private int _countEnemyes;
    [SerializeField] private float _delayBetweenSpawns;
    [SerializeField] private float _delayAfterWave;
    [SerializeField] private int[] _spawnPointsIndexes;

    public Enemy Template => _prefab;
    public int Count => _countEnemyes;
    public float Delay => _delayBetweenSpawns;
    public float DelayAfter => _delayAfterWave;

    public int[] GetSpawnpointIndexes()
    {
        int[] spawnPointsIndexes = new int[_spawnPointsIndexes.Length];

        for (int i = 0; i < _spawnPointsIndexes.Length; i++)
        {
            spawnPointsIndexes[i] = _spawnPointsIndexes[i];
        }

        return spawnPointsIndexes;
    }
}
