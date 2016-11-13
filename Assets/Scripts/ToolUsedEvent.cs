
using System;
using System.Collections.Generic;
using UnityEngine;

public class ToolUsedEvent {

    public List<Action<string>> _callbacks = new List<Action<string>>();

    public void Subscribe(Action<string> callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish(string tool)
    {
        foreach (Action<string> callback in _callbacks)
            callback(tool);
            
    }


    /*public void Unsubscribe(Action<string> callback)
    {
        List<Action<string>> itemsToRemove = new List<Action<string>>();
        itemsToRemove.Add(callback);

        foreach (Action<string> item in itemsToRemove)
        {
            _callbacks.Remove(item);
        }
    }*/
    
}
