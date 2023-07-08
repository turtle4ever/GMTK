using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private UnityEvent Callback;

        public virtual void Interact()
        {
            Debug.Log("Interacted with " + gameObject.name + "!");
            Callback?.Invoke();
        } 
    }
}