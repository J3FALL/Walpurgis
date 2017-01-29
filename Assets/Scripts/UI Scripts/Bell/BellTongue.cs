using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellTongue : MonoBehaviour {

    public float speed = 1.0f;

    private float MAX_DELTA = 45.0f;
    private short direction = -1;
    private float stateTime = 0.5f;
    private bool isMax = false;

	void Start () {
        	
	}

	void Update () {

        //check if tongue has reached max amplitude
        if (Mathf.Abs(gameObject.transform.localPosition.x) >= MAX_DELTA)
        {
            //start constant state timer
            if (!isMax)
            {
                isMax = true;
                stateTime = 0.5f / speed;
                //publish to all for start of constant state
                EventAggregator.MaxAmplitude.Publish(true);
            }
            else
            {
                stateTime -= Time.deltaTime;

                //change direction of moving
                if (stateTime <= 0.0f)
                {
                    isMax = false;
                    direction *= -1;
                    //publish to all for finish of constant state
                    EventAggregator.MaxAmplitude.Publish(false);
                }
            }
        }

        if (!isMax)
        {
            gameObject.transform.localPosition += new Vector3(speed * direction, 0, 0);
        }
	}

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetDirection()
    {
        return direction;
    }
}
