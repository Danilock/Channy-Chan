using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;

namespace UI
{
    public class InventoryUI : MenuController
    {
        [SerializeField] private GameObject _scrollViewContent;
        [SerializeField] private SlotUI _slotPrefab;

        [SerializeField] private GameObject _itemArea;

        [SerializeField] private List<SlotUI> _slotsInstantiated = new List<SlotUI>();

        public void InitializeSlotsUI(List<Slot> slots)
        {
            foreach(Slot currentSlot in slots)
            {
                SlotUI slotUI = Instantiate(_slotPrefab, _scrollViewContent.transform);

                slotUI.transform.SetParent(_scrollViewContent.transform);

                if (!currentSlot.IsEmpty)
                {
                    slotUI.UpdateSlotData(currentSlot);
                }

                _slotsInstantiated.Add(slotUI);
            }
        }

        public override void OnMenuOpen()
        {
            base.OnMenuOpen();

            _itemArea.SetActive(true);

            InitializeSlotsUI(PlayerInventory.Instance.Inventory.GetSlots);
        }

        public override void OnMenuClose()
        {
            base.OnMenuClose();

            _itemArea.SetActive(false);

            EmptyInventoryUI();
        }

        public void EmptyInventoryUI()
        {
            if (_slotsInstantiated.Count == 0)
                return;

            foreach (SlotUI slotUI in _slotsInstantiated)
            {
                Destroy(slotUI.gameObject);
            }

            _slotsInstantiated.Clear();
        }
    }
}