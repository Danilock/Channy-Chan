using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace InventorySystem
{
    [System.Serializable]
    public class Slot
    {
        public Item Item = new Item();

        private bool _isEmpty = true;
        public bool IsEmpty
        {
            get => Item.Profile == null || Item.Amount == 0;
            set => _isEmpty = value;
        }

        public UnityAction OnItemUse;

        public void UseItem()
        {
            Item.Amount -= 1;

            if (Item.Amount == 0)
            {
                Item.Profile = null;
                IsEmpty = true;
            }

            OnItemUse?.Invoke();
        }
    }
}