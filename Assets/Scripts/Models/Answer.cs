using UnityEngine;
using System.Collections;
using System;
public class Answer {
    private static int currentID = 0;

    public int ID;

    public string text;
    public Action activate = null;

    //ID of next speech if this answer was choosen
    public int nextSpeechID;

    public Answer(string text, int nextSpeechID = -1)
    {
        this.ID = currentID++;
        this.text = text;
        if (nextSpeechID >= 0)
        {
            this.nextSpeechID = nextSpeechID;
        }
    }

    public static void Prepare()
    {
        currentID = 0;
    }
}
