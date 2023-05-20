using UnityEngine;

public class ContinueButton : DefaultButton
{
    [SerializeField] private Canvas _pauseCanvas;

    protected override void OnButtonClick()
    {
        Debug.Log("");
        _pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
