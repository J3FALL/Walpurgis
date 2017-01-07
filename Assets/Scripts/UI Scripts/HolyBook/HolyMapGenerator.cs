using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HolyMapGenerator : MonoBehaviour {

    //map of symbols<time, [W, A, S, D] distribution>
    private SortedDictionary<float, List<Symbol>> symbolMap;
	void Start ()
    {
        /*symbolMap = new SortedDictionary<float, List<Symbol>>();

        List<Symbol> list = new List<Symbol>();
        list.Add(new Symbol(KeyCode.W, "hui"));
        list.Add(new Symbol(KeyCode.D, "hui"));

        symbolMap.Add(1000.0f, list);

        list = new List<Symbol>();
        list.Add(new Symbol(KeyCode.S, "hui"));
        list.Add(new Symbol(KeyCode.A, "hui"));

        symbolMap.Add(2000.0f, list);*/
    }
	
	void Update () {
	
	}

    //generate symbol map as pair<indexes, list of symbols>
    public KeyValuePair<List<float>, List<List<Symbol>>> Generate()
    {

        List<float> index = new List<float>();
        List<List<Symbol>> symbols = new List<List<Symbol>>();

        index.Add(1.0f);
        index.Add(2.0f);

        List<Symbol> list = new List<Symbol>();
        list.Add(new Symbol(KeyCode.W, "hui"));
        list.Add(new Symbol(KeyCode.D, "hui"));
        symbols.Add(list);
        list = new List<Symbol>();
        list.Add(new Symbol(KeyCode.S, "hui"));
        list.Add(new Symbol(KeyCode.A, "hui"));
        symbols.Add(list);
        return new KeyValuePair<List<float>, List<List<Symbol>>>(index, symbols);
    }
}
