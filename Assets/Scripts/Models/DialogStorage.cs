using UnityEngine;
using System.Collections;
using System;
public class DialogStorage : MonoBehaviour {

    private ArrayList speeches;
    private ArrayList answers;

    public void AddSpeech(Speech speech)
    {
        speeches.Add(speech);
    }

    public void AddAnswer(Answer answer)
    {
        answers.Add(answer);
    }

    public Answer GetAnswerById(int id)
    {
        return (Answer) answers[id]; 
    }

    public Speech GetSpeechById(int id)
    {
        return (Speech) speeches[id];
    }

    public void AddAnswerToSpeech(int speechId, int answerId)
    {
        Speech speech = (Speech) speeches[speechId];
        speech.AddAnswer(answerId);
        speeches[speechId] = speech;
    }
	
    public void AddActionToAnswer(int answerId, Action action)
    {
        Answer answer = (Answer)answers[answerId];
        answer.activate = action;
        answers[answerId] = answer;
    }

    public void Prepare()
    {
        speeches = new ArrayList();
        answers = new ArrayList();
        answers.Clear();
        speeches.Clear();

        Answer.Prepare();
        Speech.Prepare();
    }
}
