using UnityEngine;

public class BallServicesManager : MonoBehaviour
{
    public BallCreator BallCreator => _ballCreator;
    public BallDetector BallDetector => _ballDetector;
    public BallDisabler BallActiveManager => _ballActiveManager;


    [SerializeField]
    private BallCreator _ballCreator;
    [SerializeField]
    private BallDetector _ballDetector;
    private BallDisabler _ballActiveManager;

    public void Init()
    {
        _ballCreator.Init();
        _ballDetector.Init(Camera.main);

        _ballActiveManager = new BallDisabler(_ballCreator.Balls);
    }
}
