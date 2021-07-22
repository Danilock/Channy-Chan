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
    [HideInInspector] public string Description;

    [Header("Stats")]
    public float Cooldown;

    public virtual void SetupAbility()
    {

    }
    public abstract void AbilityBehaviour();
}
