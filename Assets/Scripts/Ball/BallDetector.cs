using System;
using UnityEngine;

public class BallDetector : MonoBehaviour, IClickEventProvider, IMissClickEventProvider, IPauseable
{
    public event Action<Ball> OnClick;
    public event Action<Ball> OnMissClick;

    private Camera _camera;

    private bool _isWork;

    public void Init(Camera camera)
    {
        _isWork = true;

        _camera = camera;
    }
    private void Update()
    {
        if (_isWork == false) return;

        RaycastHit2D hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (Input.GetMouseButtonDown(0) && hit.collider != null 
            && hit.collider.TryGetComponent(out Ball ball))
        {
            ball.OnHitBy();
            OnClick?.Invoke(ball);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isWork == false) return;

        if (collision != null && collision.TryGetComponent(out Ball ball))
        {
            OnMissClick?.Invoke(ball);
        }
    }

    public void Stop()
    {
        _isWork = false;
    }

    public void Resume()
    {
        _isWork = true;
    }
}
