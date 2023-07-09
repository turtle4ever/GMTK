using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Events
{
    public class Event : MonoBehaviour
    {
        [HideInInspector] [NonSerialized] public Action OnEventDelayFinished;

        private EventSO _eventSO;
        private float _timer;

        private bool _finished;
        
        public void StartEvent(EventSO eventSO)
        {
            _eventSO = eventSO;
            
            // Calculate delay timer including variance
            var min = eventSO.FollowUpDelay - eventSO.FollowUpVariance;
            var max = eventSO.FollowUpDelay + eventSO.FollowUpVariance;
            _timer = Random.Range(min, max);

            _finished = false;
        }

        public void Finish()
        {
            _finished = true;
        }

        private void Update()
        {
            if (!_finished)
                return;
            
            _timer -= Time.deltaTime;
            if (_timer <= 0f)
            {
                OnEventDelayFinished?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}