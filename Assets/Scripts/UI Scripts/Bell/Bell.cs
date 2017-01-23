using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour {

    Vector3 rotation;

    void Update()
    {
        rotation += Vector3.forward * 20 * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
