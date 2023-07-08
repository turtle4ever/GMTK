using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "Game/Dialogue/Dialogue")]
    public class DialogueSO : ScriptableObject
    {
        public SpeakerSO Speaker;

        public UnityEvent Callback;

        [TextArea(10, 20)]
        public string Content;

        public List<string> Options;
        public List<DialogueSO>Next;
    }
}
