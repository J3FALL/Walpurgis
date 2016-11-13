using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AnimatedText : MonoBehaviour {

    private string text;
    public float time;

    private bool inAnimate = false;

    public void SetText(string text)
    {
        this.text = text;
    }

    public string GetText()
    {
        return text;
    }

	// Use this for initialization
	void Start () {
       
	}
	
	IEnumerator AnimateText()
    {
        inAnimate = true;
        GetComponent<Text>().text = "";

        for (int i = 0; i < text.Length; i++)
        {
            GetComponent<Text>().text += text[i];
            yield return new WaitForSeconds(time);
        }

        inAnimate = false;
    }

    public void StartText()
    {
        StartCoroutine(AnimateText());
        StartCoroutine(DoAfterAnimation());
    }

    public void Disable()
    {
        text = "";
        GetComponent<Text>().text = "";
        EventAggregator.TextDisappeared.Publish();
    }

    IEnumerator DoAfterAnimation()
    {
        while (inAnimate)
            yield return new WaitForSeconds(3.0f);
        Disable();
    }
}
