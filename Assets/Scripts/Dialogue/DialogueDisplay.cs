using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dialogue
{
    public class DialogueDisplay : MonoBehaviour
    {
        [SerializeField] private GameObject RootDisplay;
        
        [SerializeField] private TMP_Text DialogueText;
        
        [SerializeField] private RawImage SpeakerProfileDisplay;
        [SerializeField] private TMP_Text SpeakerNameDisplay; 
        
        [SerializeField] private List<OptionBtn> Buttons;

        public void ShowDialogueLine(DialogueSO dialogue){
            DialogueText.text = dialogue.Content;

            SpeakerProfileDisplay.texture = dialogue.Speaker.Profile;
            SpeakerNameDisplay.text = dialogue.Speaker.Name;
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

        // TODO(calco): Maybe also reset the contents and things idk.
        public void StartDisplay()
        {
            RootDisplay.SetActive(true);
        }
        
        public void StopDisplay()
        {
            RootDisplay.SetActive(false);
        }
    }
}