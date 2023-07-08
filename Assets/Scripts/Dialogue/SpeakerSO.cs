using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "Speaker", menuName = "Game/Speaker", order = 0)]
    public class SpeakerSO : ScriptableObject
    {
        public string Name;
        public Texture Profile;
    }
}