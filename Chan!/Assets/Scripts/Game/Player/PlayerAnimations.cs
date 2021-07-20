using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Handles the player animations based on the current character.
    /// </summary>
    public class PlayerAnimations : MonoBehaviour
    {
        private static PlayerController _player;

        private static readonly int HashMove = Animator.StringToHash("Walk");
        private static readonly int HashJump = Animator.StringToHash("Jump");
        private static readonly int HashAttack = Animator.StringToHash("Attacking");

        private void Start()
        {
            _player = GetComponent<PlayerController>();
        }

        public static void TriggerWalkAnimation(bool state)
        {
            _player.CurrentCharacterAnimator.SetBool(HashMove, state);
        }

        public static void TriggerJumpAnimation(bool state)
        {
            _player.CurrentCharacterAnimator.SetBool(HashJump, state);
        }

        public static void TriggerAttackAnimation(bool state, int index)
        {
            _player.CurrentCharacterAnimator.SetTrigger(HashAttack);
            _player.CurrentCharacterAnimator.SetFloat("Attack Index", index);
        }
    }
}