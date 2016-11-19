using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private static Text tileText;
    /*private bool isInventoryHidden;
    public GameObject inventory;
    public Image inventoryBackground;*/

    public GameObject reactionPanel, currentReactionPanel = null;

    public EnemyTimer timer;
    public GameObject tooltip;

    public Instruction instruction;

    public void ItemClicked(string name)
    {
        //Debug.Log(name + " is clicked!");
        EventAggregator.ToolUsed.Publish(name);
    }

    /*public void ShowInventory()
    {
        
        if (isInventoryHidden)
        {
            inventory.GetComponent<CanvasGroup>().alpha = 1f;
            inventoryBackground.CrossFadeAlpha(1f, 0f, false);
            inventory.SetActive(true);
            isInventoryHidden = false;
        }
        else
        {
            inventory.GetComponent<CanvasGroup>().alpha = 0f;
            inventoryBackground.CrossFadeAlpha(0f, 0f, false);
            inventory.SetActive(false);
            isInventoryHidden = true;
        }
    }*/

    void Start () {
        tileText = GameObject.Find("TilesCounter").GetComponent<Text>();

        /*inventory = GameObject.Find("Inventory");
        inventoryBackground = GameObject.Find("InventoryBackground").GetComponent<Image>();
        inventoryBackground.CrossFadeAlpha(0f, 0, false);
        inventory.GetComponent<CanvasGroup>().alpha = 0f;
        inventory.SetActive(false);
        isInventoryHidden = true;*/

        EventAggregator.EnemyReacted.Subscribe(OnEnemyReacted);
        EventAggregator.EnemyLaunched.Subscribe(OnEnemyLaunched);
        EventAggregator.EnemyDied.Subscribe(OnEnemyDied);

        HideTooltip();
        instruction.Hide();
    }
	
	void Update () {
	
	}

    public static void ChangeTileText(int tilesAmount)
    {
        tileText.text = "Tiles: " + tilesAmount;
    }


    void OnEnemyReacted(Enemy.EnemyReaction reaction)
    {

        if (!reaction.Equals(Enemy.EnemyReaction.Death) && !reaction.Equals(Enemy.EnemyReaction.Enrage))
        {
            if (currentReactionPanel != null)
            {
                Destroy(currentReactionPanel.gameObject);
                currentReactionPanel = null;
            }
           
           currentReactionPanel = Instantiate(reactionPanel, new Vector3(350, 400, 0),
                                                                 Quaternion.identity) as GameObject;

           switch (reaction)
           {
                case Enemy.EnemyReaction.Neutral:
                    
                    currentReactionPanel.GetComponent<ReactionLabel>().Show("Ничего не произошло", Color.gray);
                        //panel.GetComponentInChildren<Text>().text = "Ничего не произошло";
                        //panel.GetComponent<Image>().color = Color.gray;
                    break;
                case Enemy.EnemyReaction.Positive:
                    currentReactionPanel.GetComponent<ReactionLabel>().Show("Положительная реакция", Color.green);
                        //panel.GetComponentInChildren<Text>().text = "Положительная реакция";
                        //panel.GetComponent<Image>().color = Color.green;
                    break;
                case Enemy.EnemyReaction.Negative:
                    currentReactionPanel.GetComponent<ReactionLabel>().Show("Отрицательная реакция", Color.red);
                        //panel.GetComponentInChildren<Text>().text = "Отрицательная реакция";
                        //panel.GetComponent<Image>().color = Color.red;
                    break;
           }
           currentReactionPanel.transform.SetParent(GameObject.Find("Canvas").transform, true);     
        }
    }

    void OnEnemyLaunched(float time)
    {
        timer.Launch(time);
    }

    void OnEnemyDied()
    {
        timer.Stop();
        timer.Clear();
    }

    public void ShowTooltip(string description)
    {
        Vector3 mouse = Input.mousePosition;

        tooltip.GetComponentInChildren<Text>().text = description;
        tooltip.transform.position = new Vector3(mouse.x - 150, mouse.y - 50);

        tooltip.GetComponent<Image>().CrossFadeAlpha(1f, 0f, false);
        tooltip.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltip.GetComponent<Image>().CrossFadeAlpha(0f, 0f, false);
        tooltip.SetActive(false);
    }

    public void OnInstructionClicked()
    {
        if (instruction.isActive())
        {
            instruction.Hide();
        } else
        {
            instruction.Show();
        }
    }


     
}
