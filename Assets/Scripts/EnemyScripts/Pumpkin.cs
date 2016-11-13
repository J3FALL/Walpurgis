using UnityEngine;
using System.Collections;
using System;

public class Pumpkin : Enemy {

    public override void FillToolsEffects()
    {
        base.FillToolsEffects();
        ToolsEffects.Add("mirror", OnMirrorUsed);
        ToolsEffects.Add("bell", OnBellUsed);
        ToolsEffects.Add("cross", OnCrossUsed);
        ToolsEffects.Add("chalk", OnChalkUsed);
        ToolsEffects.Add("salt", OnSaltUsed);
    }

    EnemyReaction OnMirrorUsed(string tool)
    {
        //EventAggregator.EnemyReacted.Publish(EnemyReaction.Positive);
        return EnemyReaction.Positive;
    } 

    EnemyReaction OnBellUsed(string tool)
    {
        //EventAggregator.EnemyReacted.Publish(EnemyReaction.Negative);
        return EnemyReaction.Negative;
    }

    EnemyReaction OnCrossUsed(string tool)
    {
        //EventAggregator.EnemyReacted.Publish(EnemyReaction.Neutral);
        
        return EnemyReaction.Neutral;
    }

    EnemyReaction OnChalkUsed(string tool)
    {
        //EventAggregator.EnemyReacted.Publish(EnemyReaction.Death);
        //Die();
        transform.position = new Vector3(transform.position.x, transform.position.y + 8, transform.position.z); //die animation is below than idle, so needed to up
        Die();
        return EnemyReaction.Death;
    }

   EnemyReaction OnSaltUsed(string tool)
    {
        Enrage();
        return EnemyReaction.Enrage;
    }
    
}
