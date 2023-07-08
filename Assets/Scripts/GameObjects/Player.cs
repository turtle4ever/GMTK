using System;
using System.Text;
using UnityEngine;

namespace GameObjects
{
    public class Player : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody2D _rb;
        
        [Header("Movement")]
        [SerializeField] private float MovementSpeed;

        // Input
        private float _inputX;
        private float _inputY;
        
        private void Awake()
        {
            _animator.Play("idle");
        }

        private void Update()
        {
            _inputX = Input.GetAxisRaw("Horizontal");
            _inputY = Input.GetAxisRaw("Vertical");

            _rb.velocity = new Vector2(_inputX, _inputY).normalized * MovementSpeed;
            
            _animator.Play($"Walk${VecToCardinal(_inputX, _inputY)}");
        }

        private static string VecToCardinal(float x, float y)
        {
            if (Math.Abs(x) > Math.Abs(y))
                return x > 0 ? "East" : "West";

            return y > 0 ? "North" : "South";
        }
    }
}
