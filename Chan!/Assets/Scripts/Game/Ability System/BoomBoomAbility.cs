using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

[CreateAssetMenu(fileName = "Boom Boom Ability", menuName = "Create Ability/BoomBoom")]
public class BoomBoomAbility : BaseAbility
{
    [Header("Boom Boom Properties")]
    [SerializeField] private float _boomBoomSize = .3f;
    [SerializeField] private LayerMask _layers;
    public override void AbilityBehaviour()
    {
        AttacksManager.DoAttackInCircleArea
            (Owner.transform.position,
             _boomBoomSize,
             _layers,
             Owner.Damageable,
             GetDamageBasedInOwner
            );
    }

    public override void AbilityGizmos(MonoBehaviour mono)
    {
        Gizmos.DrawWireSphere(mono.transform.position, _boomBoomSize);
    }
}
