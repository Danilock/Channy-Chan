using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    /// <summary>
    /// Represents a damageable object in game.
    /// </summary>
    [DisallowMultipleComponent]
    public class DamageableComponent : MonoBehaviour
    {
        #region Fields
        [SerializeField] private int _startHealth;

        private int _currentHealth;

        public int CurrentHealth
        {
            get => _currentHealth;
            private set => _currentHealth = value;
        }

        public DamageableTeam Team = DamageableTeam.PlayerFriendly;

        /// <summary>
        /// Called everytime this entity takes damage and returns the current health.
        /// </summary>
        public UnityAction<int, int> OnTakeDamage;
        public UnityAction OnDead;
        public Element Element;
        [HideInInspector] public bool IsDead, IsInvulnerable;
        Character _character;
        #endregion

        private void Start()
        {
            _character = GetComponent<Character>();

            Element = _character.Element;
            _startHealth = _character.Profile.BaseHealth;
            _currentHealth = _character.Profile.BaseHealth;
        }

        /// <summary>
        /// Makes damage to this damageable entity.
        /// </summary>
        /// <param name="amount">Amount of damage</param>
        /// <param name="damageDealerElement">Element of the damage dealer.</param>
        public void TakeDamage(int amount, DamageDealer dealer)
        {
            if (IsDead || IsInvulnerable || dealer.Team == Team)
                return;

            int damageTaked = CalculateDamageBasedOnElements(amount, dealer.Element, Element);

            CurrentHealth -= damageTaked;

            if (CurrentHealth <= 0)
            {
                IsDead = true;
                OnDead?.Invoke();
            }
            else
                OnTakeDamage?.Invoke(CurrentHealth, damageTaked);
        }

        /// <summary>
        /// Adds extra damage to the incoming damage based on the elements.
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="damageDealerElement"></param>
        /// <param name="damageReceiver"></param>
        /// <returns></returns>
        public int CalculateDamageBasedOnElements(int damage, Element damageDealerElement, Element damageReceiver)
        {
            float damageFloat = damage;

            if (damageDealerElement.StrongAgainst.Contains(damageReceiver.Type))
                damageFloat *= 1.5f;
            else if (damageDealerElement.WeakerAgainst.Contains(damageReceiver.Type))
                damageFloat *= .5f;

            return (int)damageFloat;
        }

        public void SetHealth(int value) => _currentHealth = value;
    }

    public enum DamageableTeam
    {
        PlayerFriendly,
        Enemy
    }
}