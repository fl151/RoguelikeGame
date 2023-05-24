using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : DefaultButton
{
    private const string MainSceneTitle = "Main";

    protected override void OnButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(MainSceneTitle, LoadSceneMode.Single);
    }
}
