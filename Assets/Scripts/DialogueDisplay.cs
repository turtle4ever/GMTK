using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueDisplay : MonoBehaviour
{
	[SerializeField]private TMP_Text DialogueText;
    [SerializeField]private List<OptionBtn> Buttons;

    public void ShowDialogueLine(DialogueSO Dialogue){
        DialogueText.text = Dialogue.Content;
    }
    public void ShowDialogueOptions(DialogueSO Dialogue){
        for(int i=0; i<Buttons.Count; i++){
            Buttons[i].ChangeContent(Dialogue.Options[i]);
        }
    }

}