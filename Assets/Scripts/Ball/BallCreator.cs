using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour, IPauseable 
{
    public List<Ball> Balls => _ballPool.PoolList;

    [SerializeField]
    private Ball _prefab;
    [SerializeField]
    private int _ballsAmount;
    [SerializeField]
    private Transform _spawnPos;
    private float _randomScope;
    [SerializeField]
    private float _timeBtwSpawn;
    [SerializeField]
    private float _speedUpdateStep;
    [SerializeField]
    private float _startBallSpeed;

    private Pool<Ball> _ballPool;

    private Color _randomColor;
    private Vector3 _randomPos;

    private float _lastTick;
    private float _ballsSpeed;

    private bool _isWork;
    public void Init()
    {
        _isWork = true;

        _ballsSpeed = _startBallSpeed;

        var listForPool = new List<Ball>(_ballsAmount);

        for (int i = 0; i < _ballsAmount; i++)
        {
            Ball ball = Instantiate(_prefab);
            ball.Init(Color.red, 5, 1, 1);
            listForPool.Add(ball);
        }

        _ballPool = new Pool<Ball>(listForPool);
    }
    public void Stop()
    {
        _isWork = false;
    }

    public void Resume()
    {
        _ballsSpeed = _startBallSpeed;
        _isWork = true;
        _lastTick = Time.time + _timeBtwSpawn;
    }
    private void Update()
    {
        if (_isWork && Time.time > _lastTick)
        {
            _lastTick += _timeBtwSpawn;

            var ball = _ballPool.GetElement();
            ball.Init(_randomColor.GetRandom(), _ballsSpeed, 1, 1);
            ball.SetPosition(_randomPos.GetRandomPosition(_spawnPos.position));
    
            _ballsSpeed += _speedUpdateStep;
        }
    }
    
}
