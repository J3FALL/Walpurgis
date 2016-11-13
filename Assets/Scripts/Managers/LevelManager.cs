using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    public enum EnemyStatus {NotExists, Spawned, Moving, Launched, Destroyed};
    public enum UnitStatus {NotExists, Spawned, Moving, Launched, Active, Destroyed};
    UnitStatus unitStatus = UnitStatus.NotExists;
    public GameObject[] units;
    public Player player;
    public GameObject currentUnit;
    public GameObject reactionPanel;

    private bool isEnemyEnabled = true;

	void Start () {
        //player = GetComponent<Player>();
        SpawnUnits();
        EventAggregator.EnemyEnraged.Subscribe(OnEnemyEnragedCallback);
        //EventAggregator.EnemyDied.Subscribe(OnEnemyDiedCallback);
        EventAggregator.EnemyDestroyed.Subscribe(OnEnemyDestroyedCallback);
        //EventAggregator.EnemyReacted.Subscribe(OnEnemyReactedCallback);
        EventAggregator.ToolUsed.Subscribe(OnToolUsedCallback);
        EventAggregator.LevelCompleted.Subscribe(OnLevelCompleted);
        EventAggregator.AliquotTileReached.Subscribe(OnAliquotTileReached);
    }
	

	void Update ()
    {
        if (unitStatus.Equals(UnitStatus.Spawned))
        {
            if (currentUnit.GetComponent<Unit>().isReady(player.transform))
            {
                unitStatus = UnitStatus.Launched;
            }
        }
    }
	

    void SpawnUnits()
    {
        if (isEnemyEnabled)
        {
            //Get random enemy from enemy list
            GameObject unit = units[Random.Range(0, units.Length)];
            float delta = unit.GetComponent<SpriteRenderer>().bounds.size.y / 2 - player.GetComponent<SpriteRenderer>().bounds.size.y / 2;
            //Instance new enemy
            currentUnit = Instantiate(unit, new Vector3(player.transform.position.x + Screen.width / 5, player.transform.position.y + delta, player.transform.position.z),
                                              Quaternion.identity) as GameObject;
            unitStatus = UnitStatus.Spawned;
            //subscribe to EnemyDied/EnemyEnragedEvents
        }
        else
        {
            unitStatus = UnitStatus.NotExists;
        }
    }

    /*void SpawnEnemies()
    {
        if (isEnemyEnabled)
        {
            //Get random enemy from enemy list
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            float delta = enemy.GetComponent<SpriteRenderer>().bounds.size.y / 2 - player.GetComponent<SpriteRenderer>().bounds.size.y / 2;
            //Instance new enemy
            currentEnemy = Instantiate(enemy, new Vector3(player.transform.position.x + Screen.width / 5, player.transform.position.y + delta, player.transform.position.z),
                                              Quaternion.identity) as GameObject;
            enemyStatus = EnemyStatus.Spawned;
            //subscribe to EnemyDied/EnemyEnragedEvents
        } else
        {
            enemyStatus = EnemyStatus.NotExists;
        }

    }*/

    void OnEnemyEnragedCallback()
    {
        SceneManager.LoadScene(0);
    }

    void OnEnemyDiedCallback(Enemy enemy)
    {
        //EventAggregator.EnemyDied.Unsubscribe(OnEnemyDiedCallback);
    }

    void OnEnemyDestroyedCallback()
    {
        //EventAggregator.EnemyDestroyed.Unsubscribe(OnEnemyDestroyedCallback);
        unitStatus = UnitStatus.NotExists;
        //SpawnEnemies();
    }

    void OnEnemyReactedCallback(Enemy.EnemyReaction reaction)
    {

    }

    void OnToolUsedCallback(string tool)
    {
        
        if (unitStatus.Equals(UnitStatus.Launched))
        {
            Enemy enemy = currentUnit.GetComponent<Enemy>();
            
            if (enemy != null && enemy.isActive())
            {
                Enemy.EnemyReaction reaction = enemy.CheckToolReaction(tool);
                if (reaction.Equals(Enemy.EnemyReaction.Death))
                {
                    unitStatus = UnitStatus.Destroyed;
                }
            }
                                                                 
        }
    }

    public void EnemyStatusChanged(bool isClick)
    {
        isEnemyEnabled = isClick;
    } 

    void OnLevelCompleted()
    {
        //здесь должна быть кат-сцена или еще что-то
        //но пока просто выкидывает на стартовый экран
        SceneManager.LoadScene(0);
    }

    private int initialRandomValue = 0;
    private int deltaRandom = 25;
    void OnAliquotTileReached()
    {
        if (unitStatus.Equals(UnitStatus.NotExists))
        {
            //random, если ок, то спавним, иначе меняем условия рандома
            int result = Random.Range(initialRandomValue, 100);
            if (result > 50)
            {
                initialRandomValue = 0;
                //spawn unit
                SpawnUnits();
            }
            else
            {
                initialRandomValue += deltaRandom;
            }
        }
        
    }

}
