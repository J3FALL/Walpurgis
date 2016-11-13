using UnityEngine;
using UnityEngine.UI;


public class EnemyTimer : MonoBehaviour {

    public Progress progress;
    private float timeLeft;
    private bool isLaunched = false;
    private Text text;
	void Start()
    {
        text = GetComponent<Text>();
        text.text = "";

        gameObject.SetActive(false);
        //progress = GetComponent<Progress>();
    }
	

	void Update () {
        if (isLaunched)
        {
            timeLeft -= Time.deltaTime;
            int seconds = Mathf.CeilToInt(timeLeft);

            if (seconds < 10)
            {

                text.text = string.Concat("00:0", seconds);
            }
            else
            {
                text.text = string.Concat("00:", seconds);
            }

            if (timeLeft <= 0)
            {
                isLaunched = false;
                text.text = "00:00";
            }
        }
	}

    public void Launch(float time)
    {
        gameObject.SetActive(true);
        timeLeft = time;
        isLaunched = true;

        int seconds = Mathf.CeilToInt(timeLeft);
        
        if (seconds < 10)
        {
            
            text.text = string.Concat("00:0", seconds);
        }
        else
        {
            text.text = string.Concat("00:", seconds);
        }

        //progress.gameObject.SetActive(true);
        progress.UpdateProgress(time);
    }

    public void Stop()
    {
        isLaunched = false;
        progress.Stop();
        gameObject.SetActive(false);
        //progress.gameObject.SetActive(false);
    }

    public void Clear()
    {
        text.text = "";
    }
}
