using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Element", menuName = "Create Element")]
public class ScriptableElement : ScriptableObject
{
    public string Name;
    public Element[] WeakerAgainst;
    public Element[] StrongAgainst;
}

public enum Element
{
    Fire,
    Water,
    Earth
}