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

        public static readonly int HashMove = Animator.StringToHash("Walk");
        public static readonly int HashJump = Animator.StringToHash("Jump");
        public static readonly int HashAttack = Animator.StringToHash("Attacking");
        public static readonly int HashAbility = Animator.StringToHash("UseAbility");

        private void Start()
        {
            _player = GetComponent<PlayerController>();
        }

        /// <summary>
        /// Calls the walk animation.
        /// </summary>
        /// <param name="state">If it's true, the animation will be called.</param>
        public static void TriggerWalkAnimation(bool state)
        {
            _player.CurrentCharacterAnimator.SetBool(HashMove, state);
        }

        /// <summary>
        /// Sets the jump animation.
        /// </summary>
        /// <param name="state">If it's true, the animation will be called.</param>
        public static void TriggerJumpAnimation(bool state)
        {
            _player.CurrentCharacterAnimator.SetBool(HashJump, state);
        }
        /// <summary>
        /// Executes certain attack animation depending on the index.
        /// </summary>
        /// <param name="state">If it's true, the animation will be called.</param>
        /// <param name="index">Determines the </param>
        public static void TriggerAttackAnimation(bool state, int index)
        {
            _player.CurrentCharacterAnimator.SetTrigger(HashAttack);
            _player.CurrentCharacterAnimator.SetFloat("Attack Index", index);
        }

        public static void TriggerAbilityAnimation()
        {
            _player.CurrentCharacterAnimator.SetTrigger(HashAbility);
        }
    }
}