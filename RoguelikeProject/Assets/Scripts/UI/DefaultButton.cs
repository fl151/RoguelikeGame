using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class DefaultButton : MonoBehaviour
{
    private Button _button;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    protected abstract void OnButtonClick();
}
