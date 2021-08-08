using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

[CreateAssetMenu(fileName = "TokoPewPaw", menuName = "Create Ability/PewPaw")]
public class TokoPewPaw : BaseAbility
{
    public override void AbilityBehaviour()
    {
        Owner.GetComponent<RangeAttack>().ProjectileAttack();
    }

    public override void AbilityGizmos(MonoBehaviour mono)
    {
        
    }
}
