using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Progress : MonoBehaviour {

    Image foregroundImage;

    public int Value
    {
        get
        {
            if (foregroundImage != null)
                return (int)(foregroundImage.fillAmount * 100);
            else
                return 0;
        }

        set
        {
            if (foregroundImage != null)
                foregroundImage.fillAmount = value / 100f;
        }
    }

    void Start()
    {
        foregroundImage = gameObject.GetComponent<Image>();
        Value = 100;
    }

    public void UpdateProgress(float time)
    {
        Hashtable param = new Hashtable();
        param.Add("from", 100);
        param.Add("to", 1);
        param.Add("time", time);
        param.Add("onUpdate", "TweenedSomeValue");
        param.Add("onComplete", "OnFullProgress");
        param.Add("onCompleteTarget", gameObject);
        iTween.ValueTo(gameObject, param);
        
    }

    public void Stop()
    {
        iTween.Stop();
    }

    public void TweenedSomeValue(int val)
    {
        Value = val;
    }

    public void OnFullProgress()
    {
        Value = 0;
    }
}
