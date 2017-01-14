using UnityEngine;
using System.Collections;

public class HolyBook : MonoBehaviour {

    public float MAX_OFFSET = -70;
    private float delta = 0.0f;
    private Vector3 defaultPos;

    private bool isDragActive;

    public HolyPanelManager panelManager;

    void Start () {
        isDragActive = true;
        defaultPos = transform.position;
        EventAggregator.ChangeInputMode.Subscribe(OnChangedModeCallback);
    }

    public void OnDrag()
    {
        if (isDragActive)
        {
            delta = Input.mousePosition.x - defaultPos.x;
            if (delta < 0 && delta > MAX_OFFSET)
            {
                transform.position = new Vector3(Input.mousePosition.x, transform.position.y, transform.position.z);
            }
            else if (delta <= MAX_OFFSET)
            {
                //show HolyPanel
                panelManager.Show();
                panelManager.Init();
            }
        }
    }

    void OnChangedModeCallback(bool mode)
    {
        Debug.Log(mode);
        if (mode)
        {
            transform.position = new Vector3(defaultPos.x, transform.position.y);
            isDragActive = true;
        } else
        {
            isDragActive = false;

        }
    }
}
