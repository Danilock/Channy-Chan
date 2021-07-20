using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerMovement : Singleton<PlayerMovement>
    {
        private PlayerController _player;
        /// <summary>
        /// Determines if the player can move or not.
        /// </summary>
        public bool CanMove = true;
        private void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
                _instance = this;
        }

        private void Start()
        {
            _player = GetComponent<PlayerController>();
        }

        private void Update()
        {
            if (!CanMove)
                return;

            _player.CharacterController.Move(Mathf.Round(InputHandler.MoveVector.x), InputHandler.JumpTriggered);
        }

        public static bool IsMoving
        {
            get
            {
                return Mathf.Abs(Instance._player.Rigidbody.velocity.x) > .1f;
            }
        }
    }
}