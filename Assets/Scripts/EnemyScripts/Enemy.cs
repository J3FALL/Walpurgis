using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit {

    public enum EnemyReaction { Positive, Negative, Neutral, Death, Enrage };

    public float lifeTime;
    private float startTime;

    public SortedDictionary<string, Func<string, EnemyReaction>> ToolsEffects;

    private bool isLaunched = false;
    private bool isActivated = false;
    private bool isDead = false;
    private float playerX;

    Rigidbody2D myRigitbody2D;
    public float maxSpeed = 50f;

   
    void Start () {

        myRigitbody2D = GetComponent<Rigidbody2D>();
        
        FillToolsEffects();
        isActivated = false;
        isLaunched = false;

        EventAggregator.TextDisappeared.Subscribe(OnTextDisappeared);
	}
	
    public override void Launch()
    {
        isLaunched = true;
        Move(-50f);
        EventAggregator.EnemyMoved.Publish();
    }
    public void Activate()
    {
        isLaunched = false;
        Move(0f);
        textPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 50, gameObject.transform.position.z);
        Say("you are deadman!");
    }
    public override bool isReady(Transform pos)
    {
        if (transform.position.x - pos.position.x < 330)
        {
            playerX = pos.position.x;
            Launch();

            return true;
        } else
        {
            return false;
        }
    }

    public bool isActive()
    {
        return isActivated;
    }
    void Update () {
        if (isActivated)
        {
            if (Time.time - startTime <= lifeTime)
            {
                //player is trying to defeat enemy
            }
            else
            {
                
                //EventAggregator.EnemyEnraged.Publish();
                Enrage();
                //player lost
            }
        } else if (isLaunched)
        {
            if (transform.position.x - playerX < 150)
            {
                Activate();
            }
        }
	}

    public void Move(float speed)
    {
        GetComponent<Animator>().SetInteger("speed", (-1) * (int)speed);
        myRigitbody2D.velocity = new Vector2(speed * 0.8f, myRigitbody2D.velocity.y);
    }

    public override void Enrage()
    {
        if (!isDead)
        {
            EventAggregator.EnemyEnraged.Publish();
        }
        //Destroy(gameObject);
        //EventAggregator.EnemyDestroyed.Publish();
    }

    protected void Die()
    {
        //lose animation
        isDead = true;
        StartCoroutine(DieWithDelay());
        //EventAggregator.ToolUsed.Unsubscribe(ToolUsedCallback);

    }

    public override void Disable()
    {
        Die();
    }
    IEnumerator<WaitForSeconds> DieWithDelay()
    {
        GetComponent<Animator>().SetTrigger("death");
        //yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length);
        //need to fix
        EventAggregator.EnemyDied.Publish();
        yield return new WaitForSeconds(1.1f);
        //Destroy(gameObject);
        EventAggregator.EnemyDestroyed.Publish();
        
    }

    public virtual void FillToolsEffects()
    {
        ToolsEffects = new SortedDictionary<string, Func<string, EnemyReaction>>();
        
    }


    public EnemyReaction CheckToolReaction(string tool)
    {
        Func<string, EnemyReaction> func;
        if (ToolsEffects.TryGetValue(tool, out func))
        {
            EnemyReaction reaction = func(tool);
            EventAggregator.EnemyReacted.Publish(reaction);
            return reaction;
        }
        else
        {
            EventAggregator.EnemyReacted.Publish(EnemyReaction.Neutral);
            return EnemyReaction.Neutral;
        }
    }

    public virtual void DefaultAction(string tool)
    {

    }

    void OnTextDisappeared()
    {
        //starting enrage timer
        startTime = Time.time;
        isActivated = true;
        EventAggregator.EnemyLaunched.Publish(lifeTime);
    }
}
