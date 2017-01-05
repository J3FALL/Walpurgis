using System;
using System.Collections.Generic;

public class ChangeInputModeEvent {

    public List<Action<bool>> _callbacks = new List<Action<bool>>();

    public void Subscribe(Action<bool> callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish(bool mode)
    {
        foreach (Action<bool> callback in _callbacks)
            callback(mode);
    }

    public void Unsubscribe(Action<bool> calback)
    {
        _callbacks.Remove(calback);
    }
}
