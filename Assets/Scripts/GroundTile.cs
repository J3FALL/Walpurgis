using UnityEngine;
using System.Collections;


public class GroundTile : MonoBehaviour {

    private bool isCount = false;


    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name.ToString());
        if (other.tag == "Player" && !isCount)
        {
            //GameManager.IncreaseTileCounter();
            EventAggregator.TileReached.Publish();
            isCount = true;

            //Debug.Log("triggered");
            return;
        }
    }
}
