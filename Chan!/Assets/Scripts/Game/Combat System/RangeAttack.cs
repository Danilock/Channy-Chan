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

        [SerializeField] private PoolKey _poolKey;

        [SerializeField] private Projectile _projectile;

        private Vector2 GenerateEndPointOfLine
        {
            get
            {
                Vector2 endPoint = new Vector2(AttackSpawnPoint.position.x + _damageAreaSize, AttackSpawnPoint.position.y);

                return endPoint;
            }
        }

        private void Start()
        {
            if(_rangeType == RangeAttackType.Projectile)
                ObjectPool.Instance.GeneratePool(_poolKey.KeyName, _projectile.gameObject, _poolKey.Amount);
        }

        public override void DoAttack()
        {
            if (_rangeType == RangeAttackType.Area)
                AreaAttack();
            else if (_rangeType == RangeAttackType.Line)
                LineAttack();
            else if (_rangeType == RangeAttackType.Projectile)
                ProjectileAttack();
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


        #region Attacks Methods
        /// <summary>
        /// Creates a physics raycast circle, catches all the targets and do damage to them.
        /// </summary>
        private void AreaAttack()
        {
            AttacksManager.DoAttackInCircleArea
                (
                    AttackSpawnPoint.position,
                    _damageAreaSize, AttackLayers,
                    Owner.Damageable,
                    GetDamageBasedInOwner
                );
        }

        /// <summary>
        /// Do damage to targets by creating a raycast line.
        /// </summary>
        private void LineAttack()
        {
            AttacksManager.DoAttackInLineCast
                (
                    AttackSpawnPoint.position,
                    _damageAreaSize,
                    AttackLayers,
                    Owner.Damageable,
                    GetDamageBasedInOwner
                );
        }

        public void ProjectileAttack()
        {
            AttacksManager.GenerateProjectile(
                AttackSpawnPoint.position,
                AttackDamage,
                Owner.Damageable,
                AttackLayers,
                _poolKey
                );
        }
        #endregion

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
    Line,
    Projectile
}