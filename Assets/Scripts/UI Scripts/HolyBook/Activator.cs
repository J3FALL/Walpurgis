using UnityEngine;
using UnityEngine.UI;

public class Activator : MonoBehaviour {

    //which keycode activator listens
    public KeyCode key;

    private Color defaultColor;

	void Start () {
        defaultColor = GetComponent<Image>().color;
	}

	void Update () {
        //correct key is up
	    if (Input.GetKey(key))
        {
            //highlight this activator
            if (GetComponent<Image>().color == defaultColor)
            {
                GetComponent<Image>().color = Color.black;
            }
        } else
        {
            if (GetComponent<Image>().color != defaultColor)
            {
                //set default color of activator
                GetComponent<Image>().color = defaultColor;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //check if symbol collides with activator
        if (other.name.ToString().Contains("Symbol") && Input.GetKey(key))
        {
            //publish that success
            EventAggregator.SymbolReached.Publish(true);
            //Destroy symbol
            Destroy(other.gameObject);
        }
    }
}
