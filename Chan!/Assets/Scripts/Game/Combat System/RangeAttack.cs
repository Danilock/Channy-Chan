using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class RangeAttack : Attack
    {
        [SerializeField] private float _damageAreaSize = .3f;
        [SerializeField] private RangeAttackType _rangeType = RangeAttackType.Area;
        [SerializeField] private bool _isAttacking = false;

        private Vector2 GenerateEndPointOfLine
        {
            get
            {
                Vector2 endPoint = new Vector2(AttackSpawnPoint.position.x + _damageAreaSize, AttackSpawnPoint.position.y);

                return endPoint;
            }
        }

        public override void DoAttack()
        {
            if (_rangeType == RangeAttackType.Area)
                AreaAttack();
            else if (_rangeType == RangeAttackType.Line)
                LineAttack();
        }

        private void FixedUpdate()
        {
            if (_isAttacking)
                DoAttack();
        }

        /// <summary>
        /// Activates the range attack, and do damage every frame.
        /// </summary>
        public void StartRangeAttackContinously() => _isAttacking = true;
        /// <summary>
        /// Desactivate Range Attack.
        /// </summary>
        public void EndRangeAttackContinously() => _isAttacking = false;

        public void DoRangeAttack() => DoAttack();

        /// <summary>
        /// Creates a physics raycast circle, catches all the targets and do damage to them.
        /// </summary>
        private void AreaAttack()
        {
            Collider2D[] targetsHitted = Physics2D.OverlapCircleAll(AttackSpawnPoint.position, _damageAreaSize, AttackLayers);

            DoDamageToTargets(targetsHitted);
        }

        /// <summary>
        /// Do damage to targets by creating a raycast line.
        /// </summary>
        private void LineAttack()
        {
            RaycastHit2D[] targetsHitted = Physics2D.LinecastAll(AttackSpawnPoint.position, GenerateEndPointOfLine, AttackLayers);

            DoDamageToTargets(targetsHitted);
        }

        /// <summary>
        /// Do damage to all targets collider.
        /// </summary>
        /// <param name="targetsHitted"></param>
        private void DoDamageToTargets(Collider2D[] targetsHitted)
        {
            foreach (Collider2D target in targetsHitted)
            {
                DamageableComponent dmg = target.GetComponent<DamageableComponent>();

                if (dmg == null)
                    return;

                DoDamageToTarget(dmg);
            }
        }

        /// <summary>
        /// Do damage to all targets as raycasts.
        /// </summary>
        /// <param name="targetsHitted"></param>
        private void DoDamageToTargets(RaycastHit2D[] targetsHitted)
        {
            foreach (RaycastHit2D target in targetsHitted)
            {
                DamageableComponent dmg = target.collider.GetComponent<DamageableComponent>();

                if (dmg == null)
                    return;

                DoDamageToTarget(dmg);
            }
        }

        private void OnDrawGizmos()
        {
            if (AttackSpawnPoint == null)
                return;

            if (_rangeType == RangeAttackType.Line)
                Gizmos.DrawLine(AttackSpawnPoint.position, GenerateEndPointOfLine);
            else if (_rangeType == RangeAttackType.Area)
                Gizmos.DrawWireSphere(AttackSpawnPoint.position, _damageAreaSize);
        }
    }
}

public enum RangeAttackType
{
    Area,
    Line
}