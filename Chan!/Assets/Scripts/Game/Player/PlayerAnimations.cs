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
        private static readonly int HashAbility = Animator.StringToHash("UseAbility");

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

        /// <summary>
        /// Calls the ability animation of the current character.
        /// </summary>
        public static void TriggerAbilityAnimation()
        {
            _player.CurrentCharacterAnimator.SetTrigger(HashAbility);
        }

        public static void RestoreCharacterAnimatorParameters(Character ch)
        {
            ch.Animator.SetBool("Walk", false);
            ch.Animator.SetBool("Jump", false);
            ch.Animator.SetFloat("Attack Index", 0f);
        }
    }
}