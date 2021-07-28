using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    ///=======================Class Description=======================
    /// <summary>
    /// This class should be attached to every characters that handles an ability.
    /// Used to trigger the ability attached to the GameObject(Character).
    /// </summary>
    /// ==============================================================
    [DisallowMultipleComponent]
    public class AbilityComponent : MonoBehaviour
    {
        [SerializeField] private BaseAbility _scriptableAbility;
        [SerializeField] private bool _canUse = true;

        public bool CanUse
        {
            get => _canUse;
        }

        private void Start()
        {
            _scriptableAbility.Owner = GetComponent<Character>();

            _scriptableAbility.SetupAbility();
        }


        public void TriggerAbility()
        {
            if (!_canUse)
                return;

            _scriptableAbility.AbilityBehaviour();
            TriggerAbilityCooldown();
        }

        public void TriggerAbilityCooldown() => StartCoroutine(HandleAbilityCooldown_Coroutine());

        private IEnumerator HandleAbilityCooldown_Coroutine()
        {
            _canUse = false;
            yield return new WaitForSeconds(_scriptableAbility.Cooldown);
            _canUse = true;
        }
    }
}