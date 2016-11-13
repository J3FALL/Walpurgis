using System;
using System.Collections.Generic;

public class PlayerMovingEvent {

    public List<Action<float>> _callbacks = new List<Action<float>>();

    public void Subscribe(Action<float> callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish(float speed)
    {
        foreach (Action<float> callback in _callbacks)
            callback(speed);
    }

    public void Unsubscribe(Action<float> calback)
    {
        _callbacks.Remove(calback);
    }
}
