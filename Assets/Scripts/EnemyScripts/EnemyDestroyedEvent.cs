﻿using System.Collections.Generic;
using System;

public class EnemyDestroyedEvent {

    public readonly List<Action> _callbacks = new List<Action>();

    public void Subscribe(Action callback)
    {
        _callbacks.Add(callback);
    }
	
    public void Publish()
    {
        foreach (Action callback in _callbacks)
            callback();
    }

    public void Unsubscribe(Action calback)
    {
        _callbacks.Remove(calback);
    }
}

