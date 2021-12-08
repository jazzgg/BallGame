using System;

public interface IMissClickEventProvider 
{
    public event Action<Ball> OnMissClick;
}
