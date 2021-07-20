using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    /// <summary>
    /// Base class for attacks.
    /// </summary>
    public abstract class Attack : MonoBehaviour
    {
        /// <summary>
        /// Base damage of the attack. This will change depending on the owner's EXP.
        /// </summary>
        public int AttackDamage = 10;

        /// <summary>
        /// Owner of the attack.
        /// </summary>
        [SerializeField] protected Character Owner;

        /// <summary>
        /// Where should be this attack initialized.
        /// </summary>
        public Transform AttackSpawnPoint;

        [SerializeField] protected LayerMask AttackLayers;

        public abstract void DoAttack();

        public void SetOwner(Character newOner) => this.Owner = newOner;
    
        public void DoDamageToTarget(DamageableComponent dmg)
        {
            dmg.DamageableProfile.TakeDamage(AttackDamage + Owner.Damage, Owner.Element);
        }
    }
}