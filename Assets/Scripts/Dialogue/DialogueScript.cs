using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class DialogueScript : MonoBehaviour
    {
        [SerializeField] private DialogueSO DialogueTreeRoot;
        [SerializeField] private DialogueDisplay UI;

        [SerializeField] private Transform Options;

        private void Start() {
            Display();
        
            for (int i = 0; i < Options.childCount; i++)
                Options.GetChild(i).GetComponent<OptionBtn>().ChooseOption += Select;
        }
        private void Display() {
            UI.ShowDialogueLine(DialogueTreeRoot);
            UI.ShowDialogueOptions(DialogueTreeRoot);
        }

        private void Select(int option) {
            DialogueSO child = GetChild(DialogueTreeRoot, option);
            DialogueTreeRoot = child;
            
            DialogueTreeRoot.Callback.Invoke();

            if (DialogueTreeRoot.Next.Count == 0)
                UI.StopDisplay();
            else
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
