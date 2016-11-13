using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DialogPanel : MonoBehaviour {

    public GameObject answer;
    public Action<int> callback;
    public DialogStorage storage;

    private ArrayList buttons = new ArrayList();

	void Start () {

	}

	void Update () {
	   
	}

    public void UpdateContent(Speech speech) 
    {
        foreach (GameObject button in buttons) //destroy previous answers
        {
            Destroy(button);
        }
        GetComponentInChildren<Text>().text = speech.text;
        if (speech.answers.Count > 0)
        {
            AddAnswers(speech.answers);
        }
    }

    void AddAnswers(ArrayList answers)
    {
        
        //Adding Answer below speech
        foreach (int ansID in answers) {
            //instantiate a button
            GameObject answerButton = Instantiate(answer);
            buttons.Add(answerButton);
            //set it to DialogPanel
            
            answerButton.transform.SetParent(transform.Find("Answers"), false);
            Button tempButton = answerButton.GetComponent<Button>();
            tempButton.GetComponentInChildren<Text>().text = storage.GetAnswerById(ansID).text;
            //add listener
            int id = storage.GetAnswerById(ansID).ID;
            //tempButton.onClick.AddListener(() => OnAnswerClicked(id));
            //tempButton.onClick.AddListener(() => { OnAnswerClicked(id); });
            answerButton.GetComponent<Button>().onClick.RemoveAllListeners();
            answerButton.GetComponent<Button>().onClick.AddListener(() => OnAnswerClicked(id));
        }
        
    }

    public void OnAnswerClicked(int index)
    {
        callback(index);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
