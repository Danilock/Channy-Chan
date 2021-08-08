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

        public int GetDamageBasedInOwner
        {
            get => AttackDamage + Owner.Damage;
        }
    }

    public class AttacksManager
    {
        /// <summary> 
        ///Creates a physics circle to detect all targets.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="size"></param>
        /// <param name="layers"></param>
        /// <param name="damageAmount"></param>
        /// <param name="owner"></param>
        public static void DoAttackInCircleArea(Vector2 point, float size, LayerMask layers, DamageableComponent owner, int damageAmount)
        {
            Collider2D[] targetsHitted = Physics2D.OverlapCircleAll(point, size, layers);

            foreach (Collider2D currentTarget in targetsHitted)
            {
                DamageableComponent dmg = currentTarget.GetComponent<DamageableComponent>();

                if (dmg == null)
                    return;

                dmg.TakeDamage(damageAmount, DamageDealerGenerator.GenerateDealer(owner));
            }
        }

        public static void DoDamageToTarget(DamageableComponent target, DamageableComponent owner, int amount)
        {
            target.TakeDamage(amount, DamageDealerGenerator.GenerateDealer(owner));
        }

        /// <summary>
        /// Do damage to all targets as raycasts.
        /// </summary>
        /// <param name="targetsHitted"></param>
        public static void DoAttackInLineCast(Vector2 start, float size, LayerMask layers, DamageableComponent owner, int damageAmount)
        {
            RaycastHit2D[] targetsHitted = Physics2D.LinecastAll(start, GenerateEndPointOfLine(start, size), layers);

            foreach (RaycastHit2D target in targetsHitted)
            {
                DamageableComponent dmg = target.collider.GetComponent<DamageableComponent>();

                if (dmg == null)
                    return;

                DoDamageToTarget(dmg, owner, damageAmount);
            }
        }

        private static Vector2 GenerateEndPointOfLine(Vector2 initialPoint, float size)
        {
            Vector2 endPoint = new Vector2(initialPoint.x + size, initialPoint.y);

            return endPoint;
        }

        public static void GenerateProjectile(Vector2 spawnPosition, Vector2 direction, int damage, DamageableComponent owner, LayerMask layer, PoolKey pool)
        {
            Projectile prj = ObjectPool.Instance.GetObjectInPool(pool.KeyName).GetComponent<Projectile>();

            prj.transform.position = spawnPosition;
            prj.Direction = DetermineProjectileDirection(direction);
        }

        private static Vector2 DetermineProjectileDirection(Vector2 direction)
        {
            if (direction.x > 0f)
                return Vector2.right;
            else if (direction.x < 0f)
                return Vector2.left;

            return Vector2.zero;
        }
    }
}