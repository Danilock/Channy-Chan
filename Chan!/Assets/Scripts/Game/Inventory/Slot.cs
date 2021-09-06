using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [System.Serializable]
    public class Slot
    {
        public Item Item = new Item();

        private bool _isEmpty;
        public bool IsEmpty
        {
            get => Item.Profile == null;
            set => _isEmpty = value;
        }
    }
}