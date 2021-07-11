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
        public UnityAction<int> OnTakeDamage;
        public Element Element;
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

            CurrentHealth -= CalculateDamageBasedOnElements(amount, damageDealerElement, Element);
        }

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
