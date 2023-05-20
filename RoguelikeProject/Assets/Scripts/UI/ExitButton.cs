using UnityEngine;

public class ExitButton : DefaultButton
{
    protected override void OnButtonClick()
    {
        Application.Quit();
    }
}

