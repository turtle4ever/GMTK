using System;
using Events;
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

        // TODO(calco): What the frick is this?
        private EventSO _a, _b;
        public void SetEventA(EventSO eventSO)
        {
            _a = eventSO;
        }
        
        public void SetEventB(EventSO eventSO)
        {
            _b = eventSO;
        }
        
        public void QueueEvent()
        {
            EventManager.Instance.QueueEvent(_a, _b);
        }
        
        public void DequeueEvent()
        {
            EventManager.Instance.DequeueEvent(_a, _b);
        }
    }
}