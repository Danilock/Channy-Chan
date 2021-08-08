using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    /// <summary>
    /// Handles the player attacks taking in count the current character.
    /// </summary>
    [DisallowMultipleComponent]
    public class PlayerAttackController : MonoBehaviour
    {
        private PlayerController _player;

        public bool CanAttack = true;

        private bool IsCurrentCharacterAllowedToUseAbility
        {
            get => _player.CharacterHandlerInstance.CurrentCharacter.Ability.CanUse;
        }

        /// <summary>
        /// Used to determine which animation index is going to be called.
        /// </summary>
        private int _currentAttackIndex;

        private int _maxAttackIndex = 4;

        private void Awake()
        {
            _player = GetComponent<PlayerController>();
        }

        private void Start()
        {
            InputHandler.GetChanActions.Player.BasicAttack.performed += BasicAttackPerformed;
            InputHandler.GetChanActions.Player.UseAbility.performed += AbilityPerformed;

            _player.CharacterHandlerInstance.OnChangeCharacter.AddListener(SetupNewCharacterAttackIndex);

            SetupNewCharacterAttackIndex(_player.CharacterHandlerInstance.CurrentCharacter);
        }

        /// <summary>
        /// Called once the basic attack key is performed. Triggers the atack animation and increases the attack index value by 1.
        /// </summary>
        /// <param name="obj"></param>
        private void BasicAttackPerformed(InputAction.CallbackContext obj)
        {
            if (!CanAttack)
                return;

            PlayerAnimations.TriggerAttackAnimation(true, _currentAttackIndex);

            _currentAttackIndex = (_currentAttackIndex + 1) % _maxAttackIndex;

            StopAllCoroutines();
            StartCoroutine(ResetAttackIndex_Coroutine());
        }

        private void AbilityPerformed(InputAction.CallbackContext obj)
        {
            if (!IsCurrentCharacterAllowedToUseAbility || PlayerAnimations.IsUsingAbilityAnimation)
                return;

            PlayerAnimations.TriggerAbilityAnimation();
        }

        public void ResetAttackIndex() => _currentAttackIndex = 0;

        private IEnumerator ResetAttackIndex_Coroutine()
        {
            yield return new WaitForSeconds(1.5f);

            ResetAttackIndex();
        }

        private void SetupNewCharacterAttackIndex(Character ch)
        {
            StopAllCoroutines();
            ResetAttackIndex();

            _maxAttackIndex = ch.GetComponent<CharacterAttackIndexIndicator>().GetAttacksAllowed;
        }
    }
}