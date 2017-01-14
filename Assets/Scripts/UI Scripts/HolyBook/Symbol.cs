using UnityEngine;
using UnityEngine.UI;

public class Symbol : MonoBehaviour {

    private string text;
    private KeyCode key;

    private bool isFall = true;
    private float speed = 50.0f;

    public Symbol(KeyCode key, string text)
    {
        this.key = key;
        this.text = text;

        //GetComponentInChildren<Text>().text = text;
    }

    public string GetText()
    {
        return text;
    }

    public void SetText(string text)
    {
        this.text = text;
        GetComponentInChildren<Text>().text = text;
    }

    public KeyCode GetKey()
    {
        return key;
    }

    public void SetKey(KeyCode key)
    {
        this.key = key;
    }

    void Update()
    {
        if (isFall)
        {
            //falling
            //Debug.Log(speed);
            GetComponent<RectTransform>().transform.position = new Vector2(transform.position.x, transform.position.y - speed);
        }
    }

    public void StartFall(float speed)
    {
        this.speed = speed;
        isFall = true;
    }
}
