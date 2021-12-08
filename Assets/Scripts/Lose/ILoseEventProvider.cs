using System;

public interface ILoseEventProvider : IStopEventProvider
{
    public event Action OnLose;
}
