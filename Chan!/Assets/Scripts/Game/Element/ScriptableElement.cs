using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Element", menuName = "Create Element")]
public class ScriptableElement : ScriptableObject
{
    public Element Element;
}

public enum ElementTypes
{
    Fire,
    Water,
    Earth
}