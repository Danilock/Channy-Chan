using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    ///-------------------------|Class Introduction|------------------------
    /// <summary>
    /// Base Element Class.
    /// </summary>
    /// ------------------------------------------------------------------
    [System.Serializable]
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

        public Element() { }

        public Element(Element element)
        {
            this.Name = element.Name;
            this.Type = element.Type;
            this.WeakerAgainst = new List<ElementTypes>(element.WeakerAgainst);
            this.StrongAgainst = new List<ElementTypes>(element.StrongAgainst);
        }
    }
}