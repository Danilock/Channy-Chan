using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MeleeAttack : Attack
    {
        [SerializeField] protected float AreaSize = .3f;

        [SerializeField] private bool _isAttacking;

        private void FixedUpdate()
        {
            if (_isAttacking)
                DoAttack();
        }
        public override void DoAttack()
        {
            AttacksManager.DoAttackInCircleArea
                (
                    AttackSpawnPoint.position,
                    AreaSize,
                    AttackLayers,
                    Owner.Damageable,
                    GetDamageBasedInOwner
                );
        }

        public void StartMeleeAttack() => _isAttacking = true;
        public void EndMeleeAttack() => _isAttacking = false;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;

            Gizmos.DrawWireSphere(AttackSpawnPoint.position, AreaSize);
        }
    }
}