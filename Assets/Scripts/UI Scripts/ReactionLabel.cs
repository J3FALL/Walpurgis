using UnityEngine;
using UnityEngine.UI;
public class ReactionLabel : MonoBehaviour {

    public float DisplayTime = 1.5f; // Will be displayed for 2 seconds.
    public float FadeoutTime = 0.5f; // Will fade out afterwards for 1 second.

    private bool displayTimePassed = false;
    private bool fadeOutTimePassed = false;
    private bool isShown = false;
    float elapsedTime = 0f;
    float labelAlpha = 1f;
    private string TextToShow = "Demo";
    Color mainColor;
    void Update()
    {
        if (isShown)
        {
            elapsedTime += Time.deltaTime;
            if (!displayTimePassed) // We still haven't finished displaying the "full opacity version"
            {
                if (elapsedTime > DisplayTime)
                {
                    elapsedTime = 0;
                    displayTimePassed = true;
                }
            }
            else if (!fadeOutTimePassed) // We still haven't finished displaying the fade-out.
            {
                labelAlpha = (float)((FadeoutTime - elapsedTime) / FadeoutTime);
                if (elapsedTime > FadeoutTime)
                {
                    elapsedTime = 0;
                    fadeOutTimePassed = true;
                }
            }
            else // Display and fadeout have passed.
            {
                isShown = false;
                Destroy(gameObject);
                // Possibly destroy object when done?
                // Destroy(gameObject); 
                // NOTE : This must be a clone object (created via Instantiate call) so that you don't destroy the main Label prefab.
                // If you destroy the "original" prefab you cannot instantiate that kind of prefabs anymore.
            }
        }
    }

    public void Show(string text, Color color)
    {
        TextToShow = text;
        isShown = true;
        mainColor = color;
        // Possibly refresh intervals?
        // displayTimePassed = false;
        // fadeOutTimePassed = false;
        // elapsedTime = 0f;
    }
    // Possible overrides Show(string text, displayTime , fadeouttime)

    void OnGUI()
    {
        if (isShown)
        {
            if (Mathf.Approximately(labelAlpha, 1f))
            {
                GetComponentInChildren<Text>().text = TextToShow;
                GetComponent<Image>().color = mainColor;
            }
            else
            {
                // Set alpha before label draw (for fade)
                mainColor.a = labelAlpha;
                GetComponent<Image>().color = mainColor;
            }
        }
    }
}
