using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///-------------------------|Class Introduction|------------------------
/// <summary>
/// Base Element Class.
/// </summary>
/// ------------------------------------------------------------------
public class Element
{
    public string Name;
    public ElementTypes Type;
    public List<ElementTypes> WeakerAgainst;
    public List<ElementTypes> StrongAgainst;

    /// <summary>
    /// Generates an element.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="type"></param>
    /// <param name="weakerAgainst"></param>
    /// <param name="strongAgainst"></param>
    public Element(string name, ElementTypes type, List<ElementTypes> weakerAgainst, List<ElementTypes> strongAgainst)
    {
        this.Name = name;
        this.Type = type;
        this.WeakerAgainst = new List<ElementTypes>(weakerAgainst);
        this.StrongAgainst = new List<ElementTypes>(strongAgainst);
    }
}
