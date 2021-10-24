using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InventorySystem;
using System.Linq;

namespace UI
{
    public class ItemFilter : MonoBehaviour
    {
        private InputField _inputField;
        private InventoryUI _inventoryUI;

        private void Awake()
        {
            _inputField = GetComponent<InputField>();
            _inventoryUI = FindObjectOfType<InventoryUI>();
        }

        private void OnEnable()
        {
            _inputField.onValueChanged.AddListener(OnChange);
        }

        private void OnDisable()
        {
            _inputField.onValueChanged.RemoveListener(OnChange);
        }

        private void OnChange(string currentText)
        {
            List<Slot> slots = new List<Slot>();

            if (!string.IsNullOrEmpty(currentText))
                slots = PlayerInventory.Instance.Inventory.GetNotEmptySlots.FindAll(x => x.Item.Profile.Name.ToLower().Contains(currentText.ToLower()));
            else
                slots = PlayerInventory.Instance.Inventory.GetSlots;

            _inventoryUI.EmptyInventoryUI();

            _inventoryUI.InitializeSlotsUI(slots);
        }
    }
}
