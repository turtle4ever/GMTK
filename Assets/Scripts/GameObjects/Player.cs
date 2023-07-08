using System;
using System.Text;
using Interactions;
using UnityEngine;

namespace GameObjects
{
    public class Player : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody2D _rb;

        [Header("Interactions")] 
        [SerializeField] private Interactor _interactor;

        [Header("Movement")]
        [SerializeField] private float MovementSpeed;

        // Input
        private float _inputX;
        private float _inputY;

        private bool _inputInteract;
        
        private void Update()
        {
            // Gather input
            _inputX = Input.GetAxisRaw("Horizontal");
            _inputY = Input.GetAxisRaw("Vertical");
            _inputInteract = Input.GetKeyDown(KeyCode.Z);

            // Movement
            _rb.velocity = new Vector2(_inputX, _inputY).normalized * MovementSpeed;
            
            // TODO(calco): Maybe play an idle anim idk.
            if (Mathf.Abs(_inputX + _inputY) > 0.1f)
                _animator.Play(GetAnimationString());
            
            // Interactions
            if (_inputInteract)
                _interactor.TryInteract();
        }

        private string GetAnimationString()
        {
            if (Mathf.Abs(_inputX + _inputY) <= 0.1f)
                return "Idle";
            
            return $"Walk{VecToCardinal(_inputX, _inputY)}";
        }
        
        private static string VecToCardinal(float x, float y)
        {
            if (Math.Abs(x) > Math.Abs(y))
                return x > 0 ? "East" : "West";

            return y > 0 ? "North" : "South";
        }
    }
}
