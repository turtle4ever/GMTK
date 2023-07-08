using System;
using UnityEngine;

namespace Interactions
{
    public class Interactor : MonoBehaviour
    {
        private Interactable _currentInteractable;

        public bool TryInteract()
        {
            if (_currentInteractable == null)
                return false;
            
            _currentInteractable.Interact();
            return true;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Interactable interactable))
                _currentInteractable = interactable;
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Interactable interactable))
                _currentInteractable = null;
        }
    }
}