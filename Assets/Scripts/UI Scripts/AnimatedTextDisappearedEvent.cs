using System;
using System.Collections.Generic;

public class AnimatedTextDisappearedEvent {

    public List<Action> _callbacks = new List<Action>();

    public void Subscribe(Action callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish()
    {
        foreach (Action callback in _callbacks)
        {
            callback();
        }

    }
}
