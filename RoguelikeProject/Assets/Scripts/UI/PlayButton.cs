using UnityEngine.SceneManagement;

public class PlayButton : DefaultButton
{
    private const string _MainSceneTitle = "Main";

    protected override void OnButtonClick()
    {
        SceneManager.LoadScene(_MainSceneTitle, LoadSceneMode.Single);
    }
}
