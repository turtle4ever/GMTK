using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueDisplay : MonoBehaviour
{
	[SerializeField]private TMP_Text DialogueText;
    [SerializeField]private TMP_Text DialogOptionsText;

    public void ShowDialogueLine(DialogueSO Dialogue){
        DialogueText.text = Dialogue.Content;
    }
    public void ShowDialogueOptions(DialogueSO Dialogue){
        DialogOptionsText.text = "";
        for(int i=0; i<Dialogue.Options.Count; i++){
            DialogOptionsText.text += Dialogue.Options[i]+"\n";
        }
    }

}