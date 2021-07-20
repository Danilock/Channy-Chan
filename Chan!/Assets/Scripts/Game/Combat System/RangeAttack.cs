using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class RangeAttack : Attack
    {
        [SerializeField] private float _damageAreaSize = .3f;

        public override void DoAttack()
        {
            Collider2D[] targetsHitted = Physics2D.OverlapCircleAll(AttackSpawnPoint.position, _damageAreaSize, AttackLayers);
        
            foreach(Collider2D target in targetsHitted)
            {
                DamageableComponent dmg = target.GetComponent<DamageableComponent>();

                if (dmg == null)
                    return;

                DoDamageToTarget(dmg);
            }
        }

        private void OnDrawGizmos()
        {
            
        }
    }
}