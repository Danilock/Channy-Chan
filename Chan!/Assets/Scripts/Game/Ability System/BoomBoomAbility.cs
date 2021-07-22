using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boom Boom Ability", menuName = "Create Ability/BoomBoom")]
public class BoomBoomAbility : BaseAbility
{
    public override void AbilityBehaviour()
    {
        Debug.Log(Owner.Damage);
    }
}
