using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Dialogue
{
    public class DialogueDisplay : MonoBehaviour
    {
        [SerializeField]private TMP_Text DialogueText;
        [SerializeField]private List<OptionBtn> Buttons;

        public void ShowDialogueLine(DialogueSO dialogue){
            DialogueText.text = dialogue.Content;
        }
        public void ShowDialogueOptions(DialogueSO dialogue){
            for(int i = 0; i < Buttons.Count; i++) {
                if (dialogue.Options.Count <= i) {
                    Buttons[i].gameObject.SetActive(false);
                }
                else {
                    Buttons[i].gameObject.SetActive(true);
                    Buttons[i].ChangeContent(dialogue.Options[i]);
                }
            }
        }
    }
}