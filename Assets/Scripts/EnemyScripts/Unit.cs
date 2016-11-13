
using UnityEngine;
public class Unit : MonoBehaviour {

    protected Vector3 textPosition;

    public virtual void Launch()
    {

    }

    public virtual bool isReady(Transform pos)
    {
        Launch();
        return true;
    }

    public virtual void Enrage()
    {

    }

    public virtual void Disable() { 

    }

    public void Say(string text)
    {
        AnimatedText animText = GameObject.Find("AnimatedText").GetComponent<AnimatedText>();
        Transform pos = gameObject.transform;
        animText.SetText(text);
        animText.gameObject.transform.position = textPosition;
        animText.StartText();
    }
}
