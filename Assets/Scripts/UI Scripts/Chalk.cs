using UnityEngine;
using System.Collections;

public class Chalk : MonoBehaviour {

    public void OnDrag()
    {
        transform.position = new Vector3(Input.mousePosition.x, transform.position.y, transform.position.z);
    }
}
