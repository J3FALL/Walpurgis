using UnityEngine;
using System.Collections;

public class Speech {

    private static int currentID = 0;

    public int ID;


    public string text;
    

    //Answers' IDs
    public ArrayList answers;

    public Speech(string text)
    {
        this.ID = currentID++;
        this.text = text;
        answers = new ArrayList();
    }

    public void AddAnswer(int ID)
    {
        answers.Add(ID);
    }

    public static void Prepare()
    {
        currentID = 0;
    }
}
