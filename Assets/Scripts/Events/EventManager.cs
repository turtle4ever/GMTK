using System.Collections;
using System.Collections.Generic;
using Dialogue;
using UnityEngine;
using UnityEngine.Serialization;

namespace Events
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance { get; private set; }
        
        [Header("References")]
        [SerializeField] private DialogueDisplay _dialogueDisplay;
        
        [Header("Event Settings")]
        [SerializeField] private float _randomEventChance = 0.1f;
        [SerializeField] private float _randomEventInterval = 10f;
        
        [SerializeField] private Event _emptyEventPrefab;
        
        [Header("Debug Lists")]
        [SerializeField] private List<EventSO> OngoingEvents = new();
        [SerializeField] private List<EventSO> AvailableEvents = new();
        [SerializeField] private List<EventSO> CompletedEvents = new();
        
        private readonly Dictionary<EventSO, List<EventSO>> _eventQueue = new();

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);

            StartCoroutine(TryStartRandomEvent());
        }

        private IEnumerator TryStartRandomEvent()
        {
            var random = Random.Range(0f, 1f);
            if (random <= _randomEventChance)
            {
                var randomEvent = AvailableEvents[Random.Range(0, AvailableEvents.Count)];
                StartEvent(randomEvent);
            }
            
            yield return new WaitForSeconds(_randomEventInterval);
        }

        /// <summary>
        /// Queues event B to start after event A has finished.
        /// </summary>
        /// <param name="a">The event waiting for finishing</param>
        /// <param name="b">The event to be queued</param>
        public void QueueEvent(EventSO a, EventSO b)
        {
            _eventQueue.TryAdd(a, new List<EventSO>());
            _eventQueue[a].Add(b);
        }
        
        public void DequeueEvent(EventSO a, EventSO b)
        {
            if (!_eventQueue.ContainsKey(a))
                return;
            
            _eventQueue[a].Remove(b);
        }
        
        public void StartEvent(EventSO eventSO)
        {
            // Lists
            OngoingEvents.Add(eventSO);
            
            AvailableEvents.AddRange(eventSO.Unlocks);
            AvailableEvents.RemoveAll(eventSO.Locks.Contains);
            
            if (eventSO.Unique)
                AvailableEvents.Remove(eventSO);

            var followUp = eventSO.GetRandomWeightedFollowUp();
            if (followUp != null)
                QueueEvent(eventSO, followUp);
            
            // Handle event sequencing
            var ev = Instantiate(_emptyEventPrefab, transform);
            ev.StartEvent(eventSO);
            ev.OnEventDelayFinished += () =>
            {
                OngoingEvents.Remove(eventSO);
                CompletedEvents.Add(eventSO);

                if (_eventQueue.ContainsKey(eventSO))
                {
                    foreach (var queuedEvent in _eventQueue[eventSO])
                        StartEvent(queuedEvent);
                    
                    _eventQueue.Remove(eventSO);
                }
            };
            
            // Dialogue
            _dialogueDisplay.StartDisplay(eventSO.Dialogue);
            _dialogueDisplay.OnDialogueFinished.AddListener(dialogue =>
            {
                Debug.Log("Dialogue ended.");
                
                if (dialogue != eventSO.Dialogue)
                    return;
                
                ev.Finish();
                Debug.Log("Event finished!");
            });
        }
    }
}