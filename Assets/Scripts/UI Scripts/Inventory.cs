using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public ArrayList items;

    private Item currentItem = new Item("default", "default");
    private int currentIdx;

    public Image itemIcon;
    public Vector3 basePosition;

	// Use this for initialization
	void Start () {
        //save initial position of canvas
        basePosition = transform.position;
        items = new ArrayList();
        //Item item = new Item("book", "test");
        items.Add(new Item("book", "test"));
        items.Add(new Item("mirror", "test"));
        currentIdx = 0;
        currentItem = (Item) items[currentIdx];
        
        LoadImage(currentItem.name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void NextItem()
    {
        Debug.Log("!");
        if (currentIdx + 1 < items.Count)
        {
            currentIdx++;
            currentItem = (Item) items[currentIdx];
            LoadImage(currentItem.name);
        }
    }

    public void PrevItem()
    {
        if (currentIdx - 1 >= 0)
        {
            currentIdx--;
            currentItem = (Item)items[currentIdx];
            LoadImage(currentItem.name);
        }
    }

    private void LoadImage(string name)
    {
        itemIcon.sprite = Resources.Load<Sprite>("Sprites/Items/" + name);
    }
}
