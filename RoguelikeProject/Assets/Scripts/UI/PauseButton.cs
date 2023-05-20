using UnityEngine;

public class PauseButton : DefaultButton
{
    [SerializeField] private Canvas _pauseCanvas;

    protected override void OnButtonClick()
    {
        Time.timeScale = 0;
        _pauseCanvas.gameObject.SetActive(true);
    }
}
