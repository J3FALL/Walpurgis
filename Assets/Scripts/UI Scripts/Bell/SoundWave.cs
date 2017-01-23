using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWave : MonoBehaviour {

    public int lengthOfLineRenderer = 50;
    private LineRenderer lineRenderer;

    private float currentX;

    public float amp = 10.0f;
    public float freq = 6.0f;
    //public float deltaX = 2.0f;

    private KeyCode lastKey;
    private float stableTime;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.numPositions = lengthOfLineRenderer;
        lineRenderer.useWorldSpace = true;
        lineRenderer.sortingOrder = 4;
        lineRenderer.sortingLayerName = "UI";
        currentX = transform.position.x;

        lastKey = KeyCode.D;

        stableTime = 0.5f;
    }
    void Update()
    {
        if (lastKey == KeyCode.D && Input.GetKeyDown(KeyCode.A))
        {
            freq += 0.5f;
            lastKey = KeyCode.A;
            stableTime = 2.0f;
        } else if (lastKey == KeyCode.A && Input.GetKeyDown(KeyCode.D))
        {
            freq += 0.5f;
            lastKey = KeyCode.D;
            stableTime = 2.0f;
        }

        if (Mathf.Abs(freq) > 0.001)
        {
            freq -= 0.01f;
            Debug.Log(freq);
        }

        int i = 0;
        while (i < lengthOfLineRenderer)
        {
            Vector3 pos = new Vector3(transform.position.x + i + Time.deltaTime, transform.position.y + Mathf.Sin(freq * (i + Time.time)) * amp, transform.position.z);
            lineRenderer.SetPosition(i, pos);
            i++;
        }

        stableTime -= Time.deltaTime;
        //lineRenderer.SetPosition(0, new Vector3(currentX, transform.position.y, 0));
    }
}
