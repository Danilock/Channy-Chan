using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    /// <summary>
    /// Represents a damageable object in game.
    /// </summary>
    public class DamageableComponent : MonoBehaviour
    {
        [SerializeField] private Damageable _damageable;
        public Damageable DamageableProfile
        {
            get => _damageable;
            set => _damageable = value;
        }

        [ContextMenu("Do Damage")]
        private void TakeDamage()
        {
            _damageable.TakeDamage(10, ElementGenerator.GetEarthElement);
        }
    }
}