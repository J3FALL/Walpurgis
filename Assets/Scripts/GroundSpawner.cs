using UnityEngine;
using System.Collections;

public class GroundSpawner : MonoBehaviour {

    public GameObject groundTile;
    public int startSpawnPosition;
    public int spawnYPos;
    GameObject cam;
    float lastPos;
    bool canSpawn = true;

    // Use this for initialization
    void Start () {

        EventAggregator.LevelRestarted.Subscribe(OnLevelRestarted);
        lastPos = startSpawnPosition;
        cam = GameObject.Find("Camera");
        int amount = Mathf.CeilToInt(Screen.width / (2 * 38)); //вычисляем количество тайлов, которые нужно заспавнить при старте, length = 188
        for (int i = 0; i < amount; i++)
        {
            SpawnGround();
        }
    }
	
	// Update is called once per frame
	void Update () {
        /*if (cam.transform.position.x >= (lastPos - 188) && canSpawn == true)
        {
            canSpawn = false;
            SpawnGround();
        }*/

        //Debug.Log(lastPos - cam.transform.position.x);
        if (lastPos - cam.transform.position.x < 8 * 38) // 5 - константа, поддерживает примерно 2 тайла вперед от правой границы экрана
        {
            canSpawn = false;
            SpawnGround();
        }
    }

    void SpawnGround()
    {
        Instantiate(groundTile, new Vector3(lastPos, spawnYPos, -621), Quaternion.Euler(0, 0, 0));
        lastPos += 38;
        //System.Console.WriteLine(lastPos);
        //Debug.Log(lastPos);
        canSpawn = true;
    }

    void OnLevelRestarted()
    {
        lastPos = startSpawnPosition;
        cam = GameObject.Find("Camera");
        int amount = Mathf.CeilToInt(Screen.width / (2 * 38)); //вычисляем количество тайлов, которые нужно заспавнить при старте, length = 188
        for (int i = 0; i < amount; i++)
        {
            SpawnGround();
        }
    }
}
