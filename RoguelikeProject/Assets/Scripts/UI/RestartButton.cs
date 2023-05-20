using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : DefaultButton
{
    protected override void OnButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
