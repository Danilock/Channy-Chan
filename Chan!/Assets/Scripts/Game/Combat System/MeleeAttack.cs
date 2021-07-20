using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MeleeAttack : Attack
    {
        [SerializeField] protected float AreaSize = .3f;

        [SerializeField] private bool _isAttacking;

        public void StartMeleeAttack() => _isAttacking = true;
        public void EndMeleeAttack() => _isAttacking = false;

        private void FixedUpdate()
        {
            if (_isAttacking)
                DoAttack();
        }

        public override void DoAttack()
        {
            //Creates a physics circle to detect all targets.
            Collider2D[] targets = Physics2D.OverlapCircleAll(AttackSpawnPoint.position, AreaSize, AttackLayers);

            foreach(Collider2D currentTarget in targets)
            {
                DamageableComponent dmg = currentTarget.GetComponent<DamageableComponent>();

                if (dmg != null)
                    DoDamageToTarget(dmg);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;

            Gizmos.DrawWireSphere(AttackSpawnPoint.position, AreaSize);
        }
    }
}