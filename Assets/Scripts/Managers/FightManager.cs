using UnityEngine;
using System.Collections;

public class FightManager : MonoBehaviour {

    ArrayList itemsUsed;

	void Start () {
        itemsUsed = new ArrayList();
        EventAggregator.ToolUsed.Subscribe(OnToolUsedCallback);
        /*EventAggregator.EnemyEnraged.Subscribe(OnEnemyEnragedCallback);
        EventAggregator.EnemyDied.Subscribe(OnEnemyDiedCallback);*/
        EventAggregator.EnemyDestroyed.Subscribe(OnEnemyDestroyedCallback);
	}
	

	void Update () {
	
	}

   
    void OnEnemyDestroyedCallback()
    {
        itemsUsed.Clear();

    }
    void OnToolUsedCallback(string item)
    {
        itemsUsed.Add(item);

    }
}
