using System;
using UnityEngine.UI;

public class RestartButton : IResumeEventProvider
{
    public event Action OnResume;

    private Button _object;
    public RestartButton(Button restartButton)
    {
        _object = restartButton;

        _object.onClick.AddListener(RestartGame);
    }
    public void Dispose()
    {
        _object.onClick.RemoveAllListeners();
    }
    private void RestartGame()
    {
        OnResume?.Invoke();
    }
}
