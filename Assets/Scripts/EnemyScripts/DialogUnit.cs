using UnityEngine;
using System.Collections;

public class DialogUnit : Unit {

    public DialogManager dialogManager;

    private int startSpeechId;

    void Start()
    {
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        startSpeechId = 0;

    }
    public override bool isReady(Transform pos)
    {
        if (transform.position.x - pos.position.x < 150)
        {
            Launch();
            return true;
        } else
        {
            return false;
        }
    }

    public override void Launch()
    {
        EventAggregator.EnemyMoved.Publish();
        //show dialog
        dialogManager.storage.AddActionToAnswer(0, Enrage);
        dialogManager.storage.AddActionToAnswer(1, Disable);
        dialogManager.ShowDialog(transform, startSpeechId);
    }

    public override void Enrage()
    {
        EventAggregator.EnemyEnraged.Publish();
    }

    public override void Disable()
    {
        //dialogManager.HideDialog();
        EventAggregator.EnemyDied.Publish();
        EventAggregator.EnemyDestroyed.Publish();

    }
    void Do()
    {
        Debug.Log("!");
    }
}
