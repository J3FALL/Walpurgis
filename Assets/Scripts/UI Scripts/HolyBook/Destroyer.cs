using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D other)
    {
        //destroy symbol if it collides with
        if (other.name.ToString().Contains("Symbol"))
        {
            //publish that fail
            EventAggregator.SymbolReached.Publish(false);
            Destroy(other.gameObject);
        }
    }
}
