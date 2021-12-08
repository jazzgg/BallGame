using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private BallServicesManager _ballServicesManager;
    [SerializeField]
    private LoseManager _loseManager;
    [SerializeField]
    private Player _player;

    private GamePauseMaker _gameStoper;
    private ClickHandler _clickHandler;

    private void Start()
    {
        InitializeServices();
        AddClickHandleables();
        AddStopables();
    }
    private void AddClickHandleables()
    {
        _clickHandler.AddClickHandleable(_player);
        _clickHandler.AddClickHandleable(_ballServicesManager.BallActiveManager);
    }
    private void AddStopables()
    {
        _gameStoper.AddStopable(_ballServicesManager.BallCreator);
        _gameStoper.AddStopable(_ballServicesManager.BallDetector);
        _gameStoper.AddStopable(_ballServicesManager.BallActiveManager);
        _gameStoper.AddStopable(_loseManager);
        _gameStoper.AddStopable(_player);
    }
    private void InitializeServices()
    {
        _ballServicesManager.Init();
        _player.Init();
        _loseManager.Init(_player);

        _gameStoper = new GamePauseMaker(_player, _loseManager);
        _clickHandler = new ClickHandler(_ballServicesManager.BallDetector, _ballServicesManager.BallDetector);
    }
    private void OnDestroy()
    {
        _clickHandler.Dispose();
        _gameStoper.Dispose();
    }
}
