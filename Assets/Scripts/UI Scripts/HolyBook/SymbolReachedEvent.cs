using System;
using System.Collections.Generic;

public class SymbolReachedEvent
{
    //0 - fail, 1 - success
    public List<Action<bool>> _callbacks = new List<Action<bool>>();

    public void Subscribe(Action<bool> callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish(bool result)
    {
        foreach (Action<bool> callback in _callbacks)
            callback(result);
    }

    public void Unsubscribe(Action<bool> calback)
    {
        _callbacks.Remove(calback);
    }
}
