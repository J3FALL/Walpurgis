using System;
using System.Collections.Generic;

public class EnemyReactionEvent {
    public List<Action<Enemy.EnemyReaction>> _callbacks = new List<Action<Enemy.EnemyReaction>>();

    public void Subscribe(Action<Enemy.EnemyReaction> callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish(Enemy.EnemyReaction reaction)
    {
        foreach (Action<Enemy.EnemyReaction> callback in _callbacks)
            callback(reaction);
    }

    public void Unsubscribe(Action<Enemy.EnemyReaction> calback)
    {
        _callbacks.Remove(calback);
    }

}
