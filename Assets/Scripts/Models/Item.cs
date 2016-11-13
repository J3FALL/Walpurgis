using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
    private static int NextID = 0;
    private int id;
    public string name;
    private string description;

    public Item(string name, string description)
    {
        this.id = NextID++;
        this.name = name;
        this.description = description;

        //load icon
    }

      
}
