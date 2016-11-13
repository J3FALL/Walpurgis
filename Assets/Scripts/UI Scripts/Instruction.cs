using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour {

    private int page = 0;
    private bool active = false;
    public Sprite[] pages;

    public void Show()
    {
        GetComponent<Image>().CrossFadeAlpha(1f, 0f, false);
        //gameObject.SetActive(true);
        page = 0;
        active = true;
    }

    public void Hide() {
        GetComponent<Image>().CrossFadeAlpha(0f, 0f, false);
        //gameObject.SetActive(false);
        page = 0;
        active = false;
    }

    public bool isActive()
    {
        return active;
    }

    public void ChangePage()
    {
        
        if (page + 1 < pages.Length)
        {
            page++;
            GetComponent<Image>().sprite = pages[page];
        }
    }

    public void OnNextPageButtoClicked()
    {
        ChangePage();
    }
}
