using System;
public interface IClickEventProvider 
{
    public event Action<Ball> OnClick;
}
