using System;
using System.Collections.Generic;

public class InventoryFocusedEvent {
    public List<Action<bool>> _callbacks = new List<Action<bool>>();

    public void Subscribe(Action<bool> callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish(bool focus)
    {
        foreach (Action<bool> callback in _callbacks)
        {
            callback(focus);
        }

    }
}
