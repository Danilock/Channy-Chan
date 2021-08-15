using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

[CreateAssetMenu(fileName = "TokoPewPaw", menuName = "Create Ability/PewPaw")]
public class TokoPewPaw : BaseAbility
{
    private RangeAttack _rangeAttackComponent;

    public override void SetupAbility()
    {
        _rangeAttackComponent = Owner.GetComponent<RangeAttack>();
    }

    public override void AbilityBehaviour()
    {
        OwnerAnimator.SetTrigger("UseAbility");
    }

    public override void AbilityGizmos(MonoBehaviour mono)
    {
        
    }
}
