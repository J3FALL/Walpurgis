using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour {

    //Vector3 rotation;
    public BellTongue tongue;

    private bool isCorrect = false;
    private float minSpeed = 1.0f;
    private float speed;
    private bool isDone = false;
    void Start()
    {
        EventAggregator.MaxAmplitude.Subscribe(OnMaxAmplitudeCallback);
        speed = minSpeed;
        tongue.SetSpeed(speed);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //correct time for pushing ?
            if (isCorrect)
            {
                //correct direction ?
                if (tongue.GetDirection() == 1)
                {
                    if (!isDone)
                    {
                        //increase speed only 1 time
                        speed += 1.0f;
                        tongue.SetSpeed(speed);
                        isDone = true;
                    }
                } else
                {
                    speed = minSpeed;
                    tongue.SetSpeed(speed);
                }
            } else
            {
                //decrease speed to min
                speed = minSpeed;
                tongue.SetSpeed(speed);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            //correct time for pushing ?
            if (isCorrect)
            {
                //correct direction ?
                if (tongue.GetDirection() == -1)
                {
                    if (!isDone)
                    {
                        //increase speed only 1 time
                        speed += 1.0f;
                        tongue.SetSpeed(speed);
                        isDone = true;
                    }
                }
                else
                {
                    speed = minSpeed;
                    tongue.SetSpeed(speed);
                }
            }
            else
            {
                //decrease speed to min
                speed = minSpeed;
                tongue.SetSpeed(speed);
            }
        }
        /*rotation += Vector3.forward * 20 * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotation);*/
    }

    void OnMaxAmplitudeCallback(bool state)
    {
        isCorrect = state;
        if (state)
        {
            isDone = false;
        } else if (!isDone)
        {
            //player didnt push any key
            if (speed - 1.0f >= minSpeed)
            {
                speed -= 1.0f;
                tongue.SetSpeed(speed);
            }
        }
    }
}
