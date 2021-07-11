using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
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
}