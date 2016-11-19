using UnityEngine;
using System.Collections;

public class Chalk : MonoBehaviour {

    private Vector3 defaultPos;
    private float delta = 0.0f;
    public float MAX_OFFSET = -70;

    public void Start()
    {
        defaultPos = transform.position;
    }

    public void OnDrag()
    {
        delta = Input.mousePosition.x - defaultPos.x;
        if (delta < 0 && delta > MAX_OFFSET)
        {
            transform.position = new Vector3(Input.mousePosition.x, transform.position.y, transform.position.z);
        } else if (delta <= MAX_OFFSET)
        {
            //enable draw mode
        }
    }
}
