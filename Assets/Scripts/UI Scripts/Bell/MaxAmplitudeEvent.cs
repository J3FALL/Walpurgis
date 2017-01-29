using System;
using System.Collections.Generic;

public class MaxAmplitudeEvent {
    //0 - finish, 1 - start
    public List<Action<bool>> _callbacks = new List<Action<bool>>();

    public void Subscribe(Action<bool> callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish(bool state)
    {
        foreach (Action<bool> callback in _callbacks)
            callback(state);
    }

    public void Unsubscribe(Action<bool> calback)
    {
        _callbacks.Remove(calback);
    }
}
