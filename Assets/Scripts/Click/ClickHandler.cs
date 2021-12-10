using System.Collections.Generic;

public class ClickHandler : IDIsposable
{
    private List<IClickHandleable> _clickHandleables;
    private IClickEventProvider _clickEventProvider;
    private IMissClickEventProvider _missClickEventProvider;
    public ClickHandler(IClickEventProvider clickEventProvider,
        IMissClickEventProvider missClickEventProvider)

    {
        _clickEventProvider = clickEventProvider;
        _missClickEventProvider = missClickEventProvider;

        _clickHandleables = new List<IClickHandleable>();
    }

    public void AddClickHandleable(IClickHandleable clickHandeable)
    {
        _clickEventProvider.OnClick += clickHandeable.OnClickByBall;
        _missClickEventProvider.OnMissClick += clickHandeable.OnMissClickByBall;

        _clickHandleables.Add(clickHandeable);
    }
    public void Dispose()
    {
        foreach (var clickHandleable in _clickHandleables)
        {
            _clickEventProvider.OnClick -= clickHandleable.OnMissClickByBall;
            _missClickEventProvider.OnMissClick -= clickHandleable.OnMissClickByBall;
        }
    }
   
}
