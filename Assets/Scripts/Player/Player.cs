using System;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour, IClickHandleable, ILoseEventProvider, IPauseable
{
    public event Action OnLose;
    public event Action OnStop;

    [SerializeField]
    private Text _scoreCount;
    [SerializeField]
    private Text _lifeCount;
    [SerializeField]
    private int _startLifeCount;

    private PlayerStats _playerStats;
    private PlayerUI _playerUI;

    public void Init()
    {
        _playerStats = new PlayerStats(_startLifeCount);
        _playerUI = new PlayerUI(_scoreCount, _lifeCount);

        _playerStats.OnNoHpLeft += () => OnLose?.Invoke();
        _playerStats.OnNoHpLeft += () => OnStop?.Invoke();
    }

    public void OnClickByBall(Ball ball)
    {
        IncreaseScore(ball);
    }

    public void OnMissClickByBall(Ball ball)
    {
        DecreaseHP(ball);
    }

    public void Stop()
    {
        _playerUI.Disable();
    }

    public void Resume()
    {
        _playerStats.SetHP(_startLifeCount);
        _playerStats.SetScore(0);

        _playerUI.Enable();

        _playerUI.SetHP(_playerStats.HPCount);
        _playerUI.SetScore(_playerStats.ScoreCount);
    }
    private void IncreaseScore(Ball ball)
    {
        _playerStats.IncreaseScore(ball.Score);
        _playerUI.SetScore(_playerStats.ScoreCount);
    }
    private void DecreaseHP(Ball ball)
    {
        _playerStats.DecreaseHP(ball.Damage);
        _playerUI.SetHP(_playerStats.HPCount);
    }
}
