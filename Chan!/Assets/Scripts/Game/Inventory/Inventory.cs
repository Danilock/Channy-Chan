using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

namespace InventorySystem
{
    [System.Serializable]
    public class Inventory
    {
        /// <summary>
        /// Inventory Slots.
        /// </summary>
        [SerializeField] private List<Slot> _slots;
        public List<Slot> GetSlots
        {
            get => _slots;
        }

        public int MaxCapacity
        {
            get => _slots.Capacity;
        }

        public UnityEvent<Item> OnAddItem;

        public Inventory(int maxCapacity, int initialSlots)
        {
            _slots = new List<Slot>(maxCapacity);

            AddSlot(initialSlots);
        }

        /// <summary>
        /// Add slots to this inventory.
        /// </summary>
        /// <param name="amount">Amount of new slots</param>
        public void AddSlot(int amount)
        {
            if (_slots.Count == _slots.Capacity)
                return;

            for (int i = 0; i < amount; i++)
                _slots.Add(new Slot());
        }

        /// <summary>
        /// Finds an empty Slot.
        /// </summary>
        /// <returns></returns>
        public Slot FindEmptySlot()
        {
            Slot emptySlot = _slots.Find(slot => slot.IsEmpty);

            return emptySlot;
        }

        /// <summary>
        /// Add Item to the inventory.
        /// </summary>
        /// <param name="newItem"></param>
        public void AddItem(Item newItem)
        {
            if (ItemAlreadyInInventory(newItem))
                return;

            Slot slot = FindEmptySlot();

            //If there's no empty slots, return.
            if (slot == null)
                return;

            slot.Item = newItem;
            slot.IsEmpty = false;
        }

        /// <summary>
        /// Check if the given item is already in the inventory and Increases amount value
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ItemAlreadyInInventory(Item item)
        {
            Slot slot = _slots.Find(x => x.Item.Profile == item.Profile);

            if (slot != null && item.Profile.IsStackableOnInventory)
            {
                slot.Item.Amount += item.Amount;
                return true;
            }
            else
                return false;
        }
    }
}