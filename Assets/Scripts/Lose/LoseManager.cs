using System;
using UnityEngine;
using UnityEngine.UI;

public class LoseManager : MonoBehaviour, IResumeEventProvider, IPauseable
{
    public event Action OnResume;

    [SerializeField]
    private GameObject _losePanelGameobject;
    [SerializeField]
    private Button _restartButtonObj;

    private ILoseEventProvider _loseEventProvider;
    private LosePanel _losePanel;
    private RestartButton _restartButton;

    public void Init(ILoseEventProvider loseEventProvider)
    {
        _loseEventProvider = loseEventProvider;
        _loseEventProvider.OnLose += Lose;

        _losePanel = new LosePanel(_losePanelGameobject);
        _restartButton = new RestartButton(_restartButtonObj);

        _restartButton.OnResume += () => OnResume?.Invoke();
    }
    public void Lose()
    {
        _losePanel.Enable();
    }
    private void OnDestroy()
    {
        _restartButton.Dispose();
        _loseEventProvider.OnLose -= Lose;
    }

    public void Stop()
    {

    }

    public void Resume()
    {
        _losePanel.Disable();
    }
}
