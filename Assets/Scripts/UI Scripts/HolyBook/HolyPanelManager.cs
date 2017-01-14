using UnityEngine;
using System.Collections.Generic;

public class HolyPanelManager : MonoBehaviour {

    public HolyMapGenerator generator;
    public GameObject basicSymbol;
    public List<Activator> activators;

    //private SortedDictionary<float, List<Symbol>> symbolMap;
    private List<float> timeLine = new List<float>();
    private List<List<Symbol>> symbols = new List<List<Symbol>>();

    private int idx = -1;
    private float time = 0.0f;

    //speed of symbols falling pixels per frame
    private float fallSpeed = 1;

    //maximum of fails of symbol catching
    private int maxFails = 3;
    private int failCounter;
    void Start () {
        //get symbols map
        KeyValuePair<List<float>, List<List<Symbol>>> kvp = generator.Generate();
        timeLine = kvp.Key;
        symbols = kvp.Value;

        failCounter = 0;
        //listen to symbol destroying and process score
        EventAggregator.SymbolReached.Subscribe(OnSymbolReachedCallback);
	}
	
	void Update () {
        //Debug.Log(time);
        if (idx + 1 < timeLine.Count)
        {
            //time for spawn new symbols ?
            if (timeLine[idx + 1] <= time)
            {
                idx++;
                //spawn symbols for current time
                for (int i = 0; i < symbols[idx].Count; i++)
                {
                    GameObject instance = (GameObject) Instantiate(basicSymbol, transform.position, Quaternion.identity);
                    Config(instance, symbols[idx][i]);
                    //start falling of symbol
                    instance.GetComponent<Symbol>().StartFall(5);
                }
            }
        }
        time += Time.deltaTime;
	}

    private void Config(GameObject instance, Symbol symbol)
    {
        //set spawn position as HolyBookPanel
        instance.transform.parent = transform;
        instance.AddComponent<Symbol>();
        instance.GetComponent<Symbol>().SetKey(symbol.GetKey());
        instance.GetComponent<Symbol>().SetText(symbol.GetText());

        if (symbol.GetKey() == KeyCode.W)
        {
            instance.transform.position = new Vector2(activators[0].transform.position.x,
                                                      activators[0].transform.position.y + 500);
        } else if (symbol.GetKey() == KeyCode.A)
        {
            instance.transform.position = new Vector2(activators[1].transform.position.x,
                                                      activators[1].transform.position.y + 500);
        } else if (symbol.GetKey() == KeyCode.S)
        {
            instance.transform.position = new Vector2(activators[2].transform.position.x,
                                                      activators[2].transform.position.y + 500);
        } else if (symbol.GetKey() == KeyCode.D)
        {
            instance.transform.position = new Vector2(activators[3].transform.position.x,
                                                      activators[3].transform.position.y + 500);
        }
    }
    
    void OnSymbolReachedCallback(bool result)
    {
        //increase fail counter if fali
        if (!result)
        {
            failCounter++;

            if (failCounter >= maxFails)
            {
                Debug.Log("!");
                //restart ?
            }
        }
    } 
}
