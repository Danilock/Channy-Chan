using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    /// <summary>
    /// Handles the player attacks taking in count the current character.
    /// </summary>
    public class PlayerAttackController : MonoBehaviour
    {
        private PlayerController _player;

        public bool CanAttack = true;

        /// <summary>
        /// Used to determine which animation index is going to be called.
        /// </summary>
        private int _currentAttackIndex;

        private int _maxAttackIndex = 3;

        private void Awake()
        {
            _player = GetComponent<PlayerController>();
        }

        private void Start()
        {
            InputHandler.GetChanActions.Player.BasicAttack.performed += BasicAttackPerformed;
        }

        private void BasicAttackPerformed(InputAction.CallbackContext obj)
        {
            if (!CanAttack)
                return;

            PlayerAnimations.TriggerAttackAnimation(true, _currentAttackIndex);

            _currentAttackIndex = (_currentAttackIndex + 1) % _maxAttackIndex;
        }

        public void ResetAttackIndex() => _currentAttackIndex = 0;
    }
}