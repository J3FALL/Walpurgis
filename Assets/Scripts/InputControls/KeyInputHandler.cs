using UnityEngine;
using System;
using System.Collections.Generic;

public class KeyInputHandler : MonoBehaviour {

    public SortedDictionary<KeyCode, Action> Handlers = new SortedDictionary<KeyCode, Action>();

    private Action action;

    void Start()
    {
        //Handlers.Add(KeyCode.Q, Test);
    }
	void Update () {
	    if (Input.GetKeyUp(KeyCode.Q))
        {
            Handlers.TryGetValue(KeyCode.Q, out action);
            if (action != null)
            {
                action();
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            Handlers.TryGetValue(KeyCode.W, out action);
            if (action != null)
            {
                action();
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            Handlers.TryGetValue(KeyCode.E, out action);
            if (action != null)
            {
                action();
            }
        }
	}

   
}
