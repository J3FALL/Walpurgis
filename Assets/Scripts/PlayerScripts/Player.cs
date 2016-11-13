using UnityEngine;

public class Player : MonoBehaviour {

    public float maxSpeed = 50f;
    bool facingRight = true;
    public Rigidbody2D myRigitbody2D;

    private Animator animator;
    private bool isActive = false;
    private bool isHolyLightActive = false;
    private bool isSmokeActive = false;
    //private int holyLightStateHash;
    public GameObject holyLight;
    public GameObject smoke;

    public GameObject inventory;
    public GameObject belt;

    void Start () {

        EventAggregator.ToolUsed.Subscribe(ToolUsedCallback);
        EventAggregator.EnemyLaunched.Subscribe(OnEnemyLaunchedCallback);
        EventAggregator.EnemyDestroyed.Subscribe(OnEnemyDestroyedCallback);
        EventAggregator.EnemyMoved.Subscribe(OnEnemyMovedCallback);
        EventAggregator.InventoryFocused.Subscribe(OnInventoryFocusedCallback);
        Move(maxSpeed);
    }
	
	void Awake()
    {
        myRigitbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        holyLight.SetActive(false);
        isHolyLightActive = false;
        smoke.SetActive(false);
        isSmokeActive = false;

        //holyLightStateHash = Animator.StringToHash("Base.GunterHolybookLight");
    }
    void FixedUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("GunterHolybookLight"))
        {
            if (!isHolyLightActive)
            {
                //show holylight
                float deltaY = holyLight.GetComponent<SpriteRenderer>().bounds.size.y / 2.5f;
                float deltaX = holyLight.GetComponent<SpriteRenderer>().bounds.size.x / 2.5f;

                holyLight.transform.position = new Vector3(transform.position.x + deltaX, transform.position.y + deltaY, holyLight.transform.position.z);
                holyLight.SetActive(true);
                isHolyLightActive = true;
            }
        } else if (animator.GetCurrentAnimatorStateInfo(0).IsName("GunterLadanSmoke"))
        {
            if (!isSmokeActive)
            {
                //show smoke
                float deltaY = GetComponent<SpriteRenderer>().bounds.size.y / 2.7f;
                float deltaX = GetComponent<SpriteRenderer>().bounds.size.x / 1.2f;
                smoke.transform.position = new Vector3(transform.position.x + deltaX, transform.position.y - deltaY, smoke.transform.position.z);
                smoke.SetActive(true);
                isSmokeActive = true;
            }

        } else 
        {
            isHolyLightActive = false;
            holyLight.SetActive(false);
            isSmokeActive = false;
            smoke.SetActive(false);
        }
    }

    void ToolUsedCallback(string tool)
    {
        if (isActive)
        {
            Debug.Log(tool);
            animator.SetTrigger(tool);
        }
    }

    public void Move(float speed)
    {
        myRigitbody2D.velocity = new Vector2(speed * 0.8f, myRigitbody2D.velocity.y);
        animator.SetInteger("speed", (int)speed);
    }

    void OnEnemyLaunchedCallback(float time)
    {
        isActive = true;
    } 

    void OnEnemyDestroyedCallback()
    {
        isActive = false;
        Move(maxSpeed);
    }


    void OnEnemyMovedCallback()
    {
        Move(0f);
    }

    void OnInventoryFocusedCallback(bool focus)
    {
        if (!focus) //hide inventory if unzoomed
        {
            HideInventory();
        }
        animator.SetBool("inventory", focus);
    }

    void ShowInventory()
    {
        inventory.transform.position = new Vector3(transform.position.x + 5, transform.position.y + 10, transform.position.z);
    }

    void HideInventory()
    {
        inventory.transform.position = inventory.GetComponent<Inventory>().basePosition;
    }
}

