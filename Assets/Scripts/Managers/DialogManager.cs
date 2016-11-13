using UnityEngine;
using System.Collections;

public class DialogManager : MonoBehaviour {

    private Speech currentSpeech;   //current node
    public DialogPanel dialogPanel;
    public DialogStorage storage;

    private void GenerateDialoguesGraph()
    {
        //here we create answers, speeches and add connections between them
        storage.AddAnswer(new Answer("First answer", 1));
        storage.AddAnswer(new Answer("Second answer", 1));
        storage.AddAnswer(new Answer("Third answer", 1));
        storage.AddSpeech(new Speech("How are you?"));
        storage.AddAnswerToSpeech(0, 0);
        storage.AddAnswerToSpeech(0, 1);
        storage.AddAnswerToSpeech(0, 2);
        storage.AddSpeech(new Speech("I'm fine. Thanks to asking me!"));
    }

   
    void Awake()
    {
        storage.Prepare();
        GenerateDialoguesGraph();
        //currentSpeech = storage.GetSpeechById(0);
        dialogPanel.callback = OnAnswerClickedCallback;
        //dialogPanel.UpdateContent(currentSpeech);
    }

    void OnAnswerClickedCallback(int index)
    {
        storage.GetAnswerById(index).activate();
        dialogPanel.UpdateContent(storage.GetSpeechById(storage.GetAnswerById(index).nextSpeechID));
        //dialogPanel.UpdateContent(speeches[answers[index].nextSpeechID]); //get next speech and create update dialogPanel
    }

    public void ShowDialog(Transform pos, int speechId)
    {
        currentSpeech = storage.GetSpeechById(speechId);
        dialogPanel.UpdateContent(currentSpeech);
        dialogPanel.transform.position = new Vector3(pos.position.x, pos.position.y + 50, pos.position.z);
        dialogPanel.Show();
    }

    public void HideDialog()
    {
        dialogPanel.Hide();
    }
}
