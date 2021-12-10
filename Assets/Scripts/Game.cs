using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private BallServicesManager _ballServicesManager;
    [SerializeField]
    private LoseManager _loseManager;
    [SerializeField]
    private Player _player;

    private GamePauseMaker _gamePauseMaker;
    private ClickHandler _clickHandler;

    private void Start()
    {
        InitializeServices();
        AddClickHandleables();
        AddPauseables();
    }
    private void AddClickHandleables()
    {
        _clickHandler.AddClickHandleable(_player);
        _clickHandler.AddClickHandleable(_ballServicesManager.BallActiveManager);
    }
    private void AddPauseables()
    {
        _gamePauseMaker.AddPauseable(_ballServicesManager.BallCreator);
        _gamePauseMaker.AddPauseable(_ballServicesManager.BallDetector);
        _gamePauseMaker.AddPauseable(_ballServicesManager.BallActiveManager);
        _gamePauseMaker.AddPauseable(_loseManager);
        _gamePauseMaker.AddPauseable(_player);
    }
    private void InitializeServices()
    {
        _ballServicesManager.Init();
        _player.Init();
        _loseManager.Init(_player);

        _gamePauseMaker = new GamePauseMaker(_player, _loseManager);
        _clickHandler = new ClickHandler(_ballServicesManager.BallDetector, _ballServicesManager.BallDetector);
    }
    private void Dispose()
    {
        _clickHandler.Dispose();
        _gamePauseMaker.Dispose();
    }
    private void OnDestroy()
    {
        Dispose();
    }
}
