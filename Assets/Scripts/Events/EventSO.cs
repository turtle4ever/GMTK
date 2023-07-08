using System.Collections.Generic;
using Dialogue;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "Event", menuName = "Game/Events/Event", order = 0)]
    public class EventSO : ScriptableObject
    {
        public DialogueSO Dialogue;
        
        public bool Unique;
        
        [Header("Follow Up Settings")]
        public float FollowUpDelay;
        public float FollowUpVariance;
        
        public List<EventSO> FollowUps;
        public List<float> FollowUpChances;
        
        [Header("Pool Settings")]
        public List<EventSO> Unlocks;
        public List<EventSO> Locks;
        
        public EventSO GetRandomWeightedFollowUp()
        {
            if (FollowUps.Count == 0 || FollowUpChances.Count == 0)
                return null;
            
            var total = 0f;
            foreach (var chance in FollowUpChances)
                total += chance;
            
            var random = Random.Range(0f, total);
            var sum = 0f;
            for (var i = 0; i < FollowUps.Count; i++)
            {
                sum += FollowUpChances[i];
                if (random <= sum)
                    return FollowUps[i];
            }

            return null;
        }
    }
}