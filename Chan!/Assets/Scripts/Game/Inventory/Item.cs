using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    /// <summary>
    /// Represents an Item in game.
    /// </summary>
    [System.Serializable]
    public class Item
    {
        public ItemData Profile;
        public int Amount;
    }
}