using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    [System.Serializable]
    public class Damageable
    {
        public int CurrentHealth;
        /// <summary>
        /// Called everytime this entity takes damage and returns the current health.
        /// </summary>
        public UnityAction<int, int> OnTakeDamage;
        public UnityAction OnDead;
        public ScriptableElement ScriptableElement;
        public bool IsDead, IsInvulnerable;

        /// <summary>
        /// Makes damage to this damageable entity.
        /// </summary>
        /// <param name="amount">Amount of damage</param>
        /// <param name="damageDealerElement">Element of the damage dealer.</param>
        public void TakeDamage(int amount, Element damageDealerElement)
        {
            if (IsDead || IsInvulnerable)
                return;

            int damageTaked = CalculateDamageBasedOnElements(amount, damageDealerElement, ScriptableElement.Element);

            CurrentHealth -= damageTaked;

            if (CurrentHealth <= 0)
            {
                IsDead = true;
                OnDead.Invoke();
            }
            else
                OnTakeDamage?.Invoke(CurrentHealth, damageTaked);
        }

        /// <summary>
        /// Adds extra damage to the incoming damage based on the elements.
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="damageDealer"></param>
        /// <param name="damageReceiver"></param>
        /// <returns></returns>
        public int CalculateDamageBasedOnElements(int damage, Element damageDealer, Element damageReceiver)
        {
            float damageFloat = damage;

            if (damageDealer.StrongAgainst.Contains(damageReceiver.Type))
                damageFloat *= 1.5f;
            else if(damageDealer.WeakerAgainst.Contains(damageReceiver.Type))
                damageFloat *= .5f;

            return (int) damageFloat;
        }
    }
}
