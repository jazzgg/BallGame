using System.Collections.Generic;

public class BallDisabler : IClickHandleable, IPauseable
{
    private List<Ball> _balls;
    public BallDisabler(List<Ball> balls)
    {
        _balls = balls;
    }
    public void DisableBall(Ball ball)
    {
        ball.Disable();
    }

    public void OnClickByBall(Ball ball)
    {
        DisableBall(ball);
    }

    public void OnMissClickByBall(Ball ball)
    {
        DisableBall(ball);
    }

    public void Resume()
    {
        
    }

    public void Stop()
    {
        foreach (var ball in _balls)
        {
            DisableBall(ball);
        }
    }
}
