using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// ==============|Class Info|==============
    /// <summary>
    /// Character 2D physics movement.
    /// </summary>
    /// ========================================
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterController2D : MonoBehaviour
    {
        #region  Physics
        [Header("Movement")]
        [SerializeField, Range(0f, 20)] private float _speedModifier;
        public float SpeedModifier
        {
            get => _speedModifier;
            set => _speedModifier = value;
        }
        [Header("Jump")]
        [SerializeField] private float _jumpForce;
        [Header("Ground Check")]
        [SerializeField] private Transform _groundCheckPosition;
        [SerializeField] private LayerMask _groundLayers;
        [SerializeField] private bool _isGrounded;
        private bool _wasGrounded;
        [SerializeField, Range(0f, 3f)] private float _size;

        public Rigidbody2D Rgb2D;

        public bool IsGrounded
        {
            get => _isGrounded;
        }

        public bool WasGrounded
        {
            get => _wasGrounded;
        }

        public bool Jumping;
        #endregion

        private bool _facingRight = true;

        private void Start()
        {
            Rgb2D = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            _wasGrounded = _isGrounded;
            _isGrounded = false;

            Collider2D[] hits = Physics2D.OverlapCircleAll(_groundCheckPosition.position, _size, _groundLayers);

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].gameObject != gameObject)
                    _isGrounded = true;
            }
        }

        public void Move(float direction, bool jump)
        {
            Rgb2D.velocity = new Vector2(direction * _speedModifier, Rgb2D.velocity.y);

            Jumping = jump;

            if (jump && _isGrounded)
                Jump();

            if (direction > 0 && !_facingRight)
                Flip();
            else if (direction < 0 && _facingRight)
            {
                Flip();
            }
        }

        public void Jump()
        {
            _isGrounded = false;

            Rgb2D.velocity = new Vector2(Rgb2D.velocity.x, 0f);
            Rgb2D.AddForce(new Vector2(0f, _jumpForce));
        }

        public void Flip()
        {
            // Switch the way the player is labelled as facing.
            _facingRight = !_facingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;

            transform.localScale = theScale;
        }

        private void OnDrawGizmos()
        {
            if (_groundCheckPosition == null)
                return;

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_groundCheckPosition.position, _size);
        }
    }
}