using UnityEngine;
using System.Collections;

public class CameraRunnerScript : MonoBehaviour {

    public Camera mainCamera;

    public Transform player;
    public KeyInputHandler keyInput;

    private float curX, curY, curZ;
    public float speed = 7;
    private float playerLastX;
    
    

    private bool transition = false;
    private bool backTransition = false;
    private bool isFocused = false;
    private float elapsed = 0.0f;
    public float duration = 1.0f;
    private float baseZoom, targetZoom = 70;
    private Vector3 targetVector, baseVector;
    private bool isInventoryActive = false;
    void Start()
    {
        curX = mainCamera.transform.position.x;
        curY = mainCamera.transform.position.y; 
        curZ = mainCamera.transform.position.z;

        playerLastX = player.position.x;

        baseZoom = mainCamera.orthographicSize;

        //Pass handler of "Q" key to KeyInput
        keyInput.Handlers.Add(KeyCode.Q, FocusOnInventory);

        EventAggregator.EnemyLaunched.Subscribe(OnEnemyLaunchedCallback);

    }
	void Update () {
        //transform.position = new Vector3(player.position.x + speed, 499, -781);
        //mainCamera.transform.position = new Vector3(curX+=2, 499, -781);

        float deltaX = player.position.x - playerLastX;
        if (Mathf.Abs(deltaX) > 0)
        {
            playerLastX += deltaX;
            mainCamera.transform.position = new Vector3(curX += deltaX, curY, curZ);
        }
        
        if (transition)
        {
            elapsed += Time.deltaTime / duration;
            mainCamera.orthographicSize = Mathf.Lerp(baseZoom, targetZoom, elapsed);
            mainCamera.transform.position = Vector3.Lerp(baseVector, targetVector, elapsed);
            if (elapsed > 1.0f)
            {
                transition = false;
                elapsed = 0.0f;
                isFocused = true;

                EventAggregator.InventoryFocused.Publish(true);
            }
            //mainCamera.transform.position.x = Mathf.Lerp(curX, player.transform.position.y, elapsed);
        }

        if (backTransition)
        {
            elapsed += Time.deltaTime / duration;
            mainCamera.orthographicSize = Mathf.Lerp(targetZoom, baseZoom, elapsed);
            mainCamera.transform.position = Vector3.Lerp(targetVector, baseVector, elapsed);
            if (elapsed > 1.0f)
            {
                backTransition = false;
                elapsed = 0.0f;
                isFocused = false;

                
            }
        }
    }

    void FocusOnInventory()
    {
        if (isInventoryActive)
        {
            if (!transition && !backTransition)
            {
                if (!isFocused)
                {
                    baseVector = mainCamera.transform.position;
                    targetVector = new Vector3(player.position.x, player.position.y, mainCamera.transform.position.z);
                    transition = true;
                }
                else
                {
                    //back transition = unzoom
                    backTransition = true;
                    EventAggregator.InventoryFocused.Publish(false);
                }
                
            }
            
        }
       
    }
    void OnEnemyLaunchedCallback(float time)
    {
        isInventoryActive = true;
    }
}
