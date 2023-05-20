using UnityEngine;

public class GameResult : MonoBehaviour
{
    [SerializeField] private Canvas _winCanvas;
    [SerializeField] private Canvas _lossCanvas;

    [SerializeField] private Player _player;

    public void SetBoss(Boss boss)
    {
        boss.Dead += OnBossDied;
    }   

    private void Start()
    {
        _player.Died += OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        Time.timeScale = 0;
        _lossCanvas.gameObject.SetActive(true);
    }

    private void OnBossDied()
    {
        Time.timeScale = 0;
        _winCanvas.gameObject.SetActive(true);
    }
}
