using UnityEngine.SceneManagement;

public class PlayButton : DefaultButton
{
    protected override void OnButtonClick()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}