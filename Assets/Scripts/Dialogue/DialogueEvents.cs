using System;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "Dialogue Events", menuName = "Game/Dialogue/Events")]
    public class DialogueEvents : ScriptableObject
    {
        public void AgreeKillAllamir()
        {
            Debug.Log("Good. Player decided to kill the cultists.");
        }

        public void DisagreeKillAllamir()
        {
            Debug.Log("Bad, how dare player disagree with kill allamir?!!?!?!?");
        }
    }
}