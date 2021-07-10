using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Create Character Profile")]
public class ScriptableCharacterProfile : ScriptableObject
{
    public Sprite Portrait;
    public Element Element;
    public string Name;

    [TextArea] public string Description;

    [Header("Stats")]
    public int BaseHealth;
    public int BaseDamage;
}