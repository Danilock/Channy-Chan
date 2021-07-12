using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerController _player;
        public bool CanMove = true;

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
    }
}