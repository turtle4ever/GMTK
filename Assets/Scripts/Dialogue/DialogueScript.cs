using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class DialogueScript : MonoBehaviour
    {
        [SerializeField] private DialogueSO DialogueTreeRoot;
        [SerializeField] private DialogueDisplay UI;

        private void Start(){
            Display();
        
            OptionBtn[] btn = FindObjectsOfType<OptionBtn>();

            foreach (var option in btn)
                option.ChooseOption += Select;
        }
        private void Display() {
            UI.ShowDialogueLine(DialogueTreeRoot);
            UI.ShowDialogueOptions(DialogueTreeRoot);
        }

        private void Select(int option) {
            DialogueSO child = GetChild(DialogueTreeRoot, option);
            DialogueTreeRoot = child;

            Display();
        }

        private DialogueSO GetChild(DialogueSO parent, int option){
            if(parent == null) {
                Debug.Log("Parent is null! (This shouldn't happen!)");
            }
            
            DialogueSO child = parent.Next[option];
            return child;
        }
    }
}
