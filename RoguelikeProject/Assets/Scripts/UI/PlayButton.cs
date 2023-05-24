using UnityEngine.SceneManagement;

public class PlayButton : DefaultButton
{
    private const string MainSceneTitle = "Main";

    protected override void OnButtonClick()
    {
        SceneManager.LoadScene(MainSceneTitle, LoadSceneMode.Single);
    }
}
