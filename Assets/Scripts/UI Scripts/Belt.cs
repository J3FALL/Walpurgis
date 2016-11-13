using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Belt : MonoBehaviour {

    public Vector3 closePosition;
    public Vector3 openPosition;

    public float duration = 2.0f;
    private float elapsed = 0.0f;

    private bool isOpened = false;
    private bool transition = false;
    private bool backTransition = false;
    public Vector3 startPos, endPos;

    public KeyInputHandler keyInput;
    void Start () {
        //save initial position outsize of screen
        closePosition = transform.position;
        openPosition = new Vector3(closePosition.x, 530, closePosition.z);

        //Pass handler of "W" key to KeyInput
        keyInput.Handlers.Add(KeyCode.W, ShowBelt);
	}
	

	void Update () {

        if (transition)
        {
            elapsed += Time.deltaTime / duration;
            transform.position = Vector3.Lerp(startPos, endPos, elapsed);

            if (elapsed > 1.0f)
            {
                transition = false;
                elapsed = 0.0f;
                isOpened = true;
            }
        }
        
        if (backTransition)
        {
            elapsed += Time.deltaTime / duration;
            transform.position = Vector3.Lerp(startPos, endPos, elapsed);

            if (elapsed > 1.0f)
            {
                backTransition = false;
                elapsed = 0.0f;
                isOpened = false;
            }
        }
	}  
    
    public void ShowBelt()
    {
        if (!transition && !backTransition)
        {
            if (!isOpened)
            {
                //open belt
                elapsed = 0.0f;
                startPos = closePosition;
                endPos = openPosition;
                transition = true;
            }
            else
            {
                //close belt
                elapsed = 0.0f;
                startPos = openPosition;
                endPos = closePosition;
                backTransition = true;

            }
        }
    }
}
