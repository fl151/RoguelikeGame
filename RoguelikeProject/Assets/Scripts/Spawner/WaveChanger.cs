using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class WaveChanger : MonoBehaviour
{
    [SerializeField] private Wave[] _waves;

    private Spawner _spawner;

    private int _currentIndexWave;

    private void Start()
    {
        _spawner = GetComponent<Spawner>();
        _currentIndexWave = -1;

        TryStartNextWave();
    }

    private void TryStartNextWave()
    {
        if(++_currentIndexWave < _waves.Length)
        {
            InitWave(_waves[_currentIndexWave]);
        }
    }

    private void InitWave(Wave wave)
    {
        StartCoroutine(PlayWave(wave));
    }

    private IEnumerator PlayWave(Wave wave)
    {
        WaitForSeconds delay = new WaitForSeconds(wave.Delay);

        for (int i = 0; i < wave.Count; i++)
        {
            yield return delay;

            _spawner.SpawnEnemy(wave.Template, wave.GetSpawnpointIndexes());
        }

        yield return new WaitForSeconds(wave.DelayAfter);

        TryStartNextWave();
    }
}
