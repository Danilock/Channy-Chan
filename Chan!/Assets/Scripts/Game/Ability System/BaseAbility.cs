using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

/// <summary>
/// Base class for scriptable abilities.
/// </summary>
public abstract class BaseAbility : ScriptableObject
{
    /// <summary>
    /// Character who owns of the ability.
    /// </summary>
    [HideInInspector] public Character Owner;

    /// <summary>
    /// Ability Name.
    /// </summary>
    public string Name;
    /// <summary>
    /// Ability Description.
    /// </summary>
    [TextArea] public string Description;

    [Header("Stats")]
    public float Cooldown;
    public int BaseDamage;

    protected int GetDamageBasedInOwner
    {
        get => BaseDamage + Owner.Damage;
    }

    public virtual void SetupAbility()
    {

    }
    public abstract void AbilityBehaviour();

    public abstract void AbilityGizmos(MonoBehaviour mono);
}
