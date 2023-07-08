using System;
using UnityEngine;

namespace Dialogue
{
    public class DialogueStarter : MonoBehaviour
    {
        [SerializeField] private DialogueSO _rootDialogue;
        [SerializeField] private DialogueDisplay _dialogueDisplay;
        
        private void Start()
        {
            StopDialogue();
        }

        public void StartDialogue()
        {
            _dialogueDisplay.StartDisplay(_rootDialogue);
        }
        
        public void StopDialogue()
        {
            _dialogueDisplay.StopDisplay();
        }
    }
}