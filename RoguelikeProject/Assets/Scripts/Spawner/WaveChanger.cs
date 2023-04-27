using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Spawner))]
public class WaveChanger : MonoBehaviour
{
    [SerializeField] private Wave[] _waves;

    private Spawner _spawner;

    private int _currentIndexWave;

    private UnityAction _waveFinished;

    private void Start()
    {
        _spawner = GetComponent<Spawner>();
        _currentIndexWave = -1;

        _waveFinished += TryStartNextWave;

        TryStartNextWave();
    }

    private void OnDisable()
    {
        _waveFinished -= TryStartNextWave;
    }

    private void TryStartNextWave()
    {
        if(_currentIndexWave + 1 < _waves.Length)
        {
            _currentIndexWave++;

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

        _waveFinished.Invoke();
    }
}
