using UnityEngine;
using System;
using System.Collections.Generic;

public class KeyInputHandler : MonoBehaviour {

    public SortedDictionary<KeyCode, Action> Handlers = new SortedDictionary<KeyCode, Action>();

    private Action action;
    private bool isActive;

    void Start()
    {
        isActive = true;
        EventAggregator.ChangeInputMode.Subscribe(ChangeInputModeCallback);
        //Handlers.Add(KeyCode.Q, Test);
    }
	void Update () {
        if (isActive)
        {
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

   void ChangeInputModeCallback(bool mode)
    {
        //switch on/off key input for items when someone is already opened/closed 
        if (mode)
        {
            isActive = true;
        } else
        {
            isActive = false;
        }
    }
}
