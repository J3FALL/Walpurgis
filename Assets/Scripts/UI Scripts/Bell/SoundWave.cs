using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWave : MonoBehaviour {

    public int lengthOfLineRenderer = 50;
    private LineRenderer lineRenderer;

    private Vector3 startPos;

    public float amp = 10.0f;
    public float freq = 6.0f;
    public float deltaX = 1f;

    private KeyCode lastKey;
    private float stableTime;

    public float minFreq = 0.1f, maxFreq = 0.7f;
    public float middleFreq;

    public float winTime = 0.5f;
    private float currentCorrectTime = 0.0f;

    private LineRenderer correctLine;

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

        lastKey = KeyCode.D;

        stableTime = 0.5f;

        middleFreq = (maxFreq - middleFreq) / 2.0f;
    }
    void Update()
    {
        if (lastKey == KeyCode.D && Input.GetKeyDown(KeyCode.A))
        {
            freq += 0.25f;
            lastKey = KeyCode.A;
            stableTime = 0.5f;
        } else if (lastKey == KeyCode.A && Input.GetKeyDown(KeyCode.D))
        {
            freq += 0.25f;
            lastKey = KeyCode.D;
            stableTime = 0.5f;
        }

        if (Mathf.Abs(freq) > 0.001)
        {
            freq -= 0.009f;
        }

        //Debug.Log(freq);
        if (freq >= minFreq && freq <= maxFreq)
        {
            if (currentCorrectTime < winTime)
            {
                currentCorrectTime += Time.deltaTime;
            } else
            {
                Debug.Log("win");
                currentCorrectTime = 0.0f;
            }
        }
        int i = 0;
        while (i < lengthOfLineRenderer)
        {
            Vector3 pos = startPos + new Vector3(deltaX * i + Time.deltaTime, amp * Mathf.Sin(freq * (i + Time.deltaTime)), 0.0f);
            //Vector3 pos = new Vector3(transform.position.x + i + Time.deltaTime, transform.position.y + Mathf.Sin(freq * (i + Time.time)) * amp, transform.position.z);
            lineRenderer.SetPosition(i, pos);

            /*Vector3 correctPos = startPos + new Vector3(deltaX * i + Time.deltaTime, amp * Mathf.Sin(middleFreq * (i + Time.deltaTime)), 0.0f);
            lineRenderer.SetPosition(i, correctPos);*/
            i++;
        }
        stableTime -= Time.deltaTime;
        //lineRenderer.SetPosition(0, new Vector3(currentX, transform.position.y, 0));
    }
}
