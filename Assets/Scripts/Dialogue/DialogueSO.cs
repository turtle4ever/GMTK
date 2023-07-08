using System.Collections.Generic;
using Events;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "Game/Dialogue/Dialogue")]
    public class DialogueSO : ScriptableObject
    {
        public SpeakerSO Speaker;

        public UnityEvent Callback;
        
        // Button

        [TextArea(10, 20)]
        public string Content;

        public List<string> Options;
        public List<DialogueSO>Next;
    }
}
