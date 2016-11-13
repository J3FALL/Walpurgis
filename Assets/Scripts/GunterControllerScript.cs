using UnityEngine;

public class GunterControllerScript : MonoBehaviour {

    public float maxSpeed = 50f;
    bool facingRight = true;
    public Rigidbody2D myRigitbody2D;

    private Animator animator;

    void Start () {
       
        //EventAggregator.EnemyLaunched.Subscribe(EnemyLaunchedCallback);
        EventAggregator.EnemyDestroyed.Subscribe(EnemyDestroyedCallback);
        EventAggregator.EnemyMoved.Subscribe(OnEnemyMovedCallback);
        Move(maxSpeed);
	}
	
    void Awake ()
    {   
        myRigitbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    	
    public void Move(float speed)
    {
        myRigitbody2D.velocity = new Vector2(speed * 0.8f, myRigitbody2D.velocity.y);
        animator.SetInteger("speed", (int) speed);
    }

	void FixedUpdate () {
        
        /*float move = Input.GetAxis("Horizontal");
        myRigitbody2D.velocity = new Vector2(move * maxSpeed, myRigitbody2D.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
        */

	}

    void EnemyLaunchedCallback()
    {
        //Move(0f);
    }

    void EnemyDestroyedCallback()
    {
        Move(maxSpeed);
    }

    void OnEnemyMovedCallback()
    {
        Move(0f);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
