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

        [SerializeField] private List<SlotUI> _slotsInitialized = new List<SlotUI>();

        private void InitializeSlotsUI()
        {
            foreach(Slot currentSlot in PlayerInventory.Instance.Inventory.GetSlots)
            {
                SlotUI slotUI = Instantiate(_slotPrefab, _scrollViewContent.transform);

                slotUI.transform.SetParent(_scrollViewContent.transform);

                if (!currentSlot.IsEmpty)
                {
                    slotUI.UpdateSlotData(currentSlot);
                }

                _slotsInitialized.Add(slotUI);
            }
        }

        public override void OnMenuOpen()
        {
            base.OnMenuOpen();

            _itemArea.SetActive(true);

            InitializeSlotsUI();
        }

        public override void OnMenuClose()
        {
            base.OnMenuClose();

            _itemArea.SetActive(false);

            EmptyInventoryUI();
        }

        private void EmptyInventoryUI()
        {
            if (_slotsInitialized.Count == 0)
                return;

            foreach (SlotUI slotUI in _slotsInitialized)
            {
                Destroy(slotUI.gameObject);
            }

            _slotsInitialized.Clear();
        }
    }
}