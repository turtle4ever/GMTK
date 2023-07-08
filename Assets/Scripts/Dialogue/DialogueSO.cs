using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "Game/Dialogue")]
    public class DialogueSO : ScriptableObject
    {
        public string Content;
        public List<string> Options;
        public List<DialogueSO>Next;
    }
}
