using System.Collections.Generic;

public class GamePauseMaker : IDIsposable
{
    private IStopEventProvider _stopEventProvider;
    private IResumeEventProvider _resumeEventProvider;
    private List<IPauseable> _stopables;

    public GamePauseMaker(IStopEventProvider stopEventProvider, IResumeEventProvider resumeEventProvider)
    {
        _stopables = new List<IPauseable>();

        _resumeEventProvider = resumeEventProvider;
        _stopEventProvider = stopEventProvider;

        _resumeEventProvider.OnResume += Resume;
        _stopEventProvider.OnStop += Stop;
    }
    public void AddPauseable(IPauseable stopable)
    {
        _stopables.Add(stopable);
    }
    public void Stop()
    {
        foreach (var stopable in _stopables)
        {
            stopable.Stop();
        }
    }
    public void Resume()
    {
        foreach (var stopable in _stopables)
        {
            stopable.Resume();
        }
    }
    public void Dispose()
    {
        _resumeEventProvider.OnResume -= Resume;
        _stopEventProvider.OnStop -= Stop;
    }
}
