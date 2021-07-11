using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;

namespace Tests
{
    ///--------------------|Class Introduction|-----------------------
    /// <summary>
    /// Generates elements using static properties.
    /// </summary>
    ///---------------------------------------------------------------
    public class ElementGenerator
    {
        /// <summary>
        /// Generates the Fire element and returns it.
        /// </summary>
        public static Element GetFireElement
        {
            get
            {
                List<ElementTypes> strongAgainst = new List<ElementTypes>()
            { ElementTypes.Earth };

                List<ElementTypes> weakerAgainst = new List<ElementTypes>()
            { ElementTypes.Water };

                Element fireElementGenerated = new Element
                    ("Fire", ElementTypes.Fire, weakerAgainst, strongAgainst);

                return fireElementGenerated;
            }
        }

        /// <summary>
        /// Generates the water element and returns it.
        /// </summary>
        public static Element GetWaterElement
        {
            get
            {
                List<ElementTypes> strongAgainst = new List<ElementTypes>()
            { ElementTypes.Fire };

                List<ElementTypes> weakerAgainst = new List<ElementTypes>()
            { ElementTypes.Earth };

                Element waterElementGenerated = new Element
                    ("Water", ElementTypes.Water, weakerAgainst, strongAgainst);

                return waterElementGenerated;
            }
        }

        /// <summary>
        /// Generates the Earth element and returns it.
        /// </summary>
        public static Element GetEarthElement
        {
            get
            {
                List<ElementTypes> strongAgainst = new List<ElementTypes>()
            { ElementTypes.Water };

                List<ElementTypes> weakerAgainst = new List<ElementTypes>()
            { ElementTypes.Earth };

                Element earthElementGenerated = new Element
                    ("Fire", ElementTypes.Fire, weakerAgainst, strongAgainst);

                return earthElementGenerated;
            }
        }
    }
}