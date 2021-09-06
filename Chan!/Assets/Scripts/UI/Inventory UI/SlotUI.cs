using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InventorySystem;
using TMPro;
using UnityEngine.EventSystems;

namespace UI
{
    public class SlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _itemImage;
        [SerializeField] private TMP_Text _itemAmount;
        private Slot _slot = new Slot();

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_slot.IsEmpty)
                return;

            UIManager.Instance.GetItemDescriptionPanel.gameObject.SetActive(true);
            UIManager.Instance.GetItemDescriptionPanel.SetDescriptionText(_slot.Item.Profile.Description);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_slot.IsEmpty)
                return;

            UIManager.Instance.GetItemDescriptionPanel.gameObject.SetActive(false);
        }

        public void UpdateSlotData(Slot slot)
        {
            _itemImage.sprite = slot.Item.Profile.Portrait;
            _itemAmount.text = $"{slot.Item.Amount}";

            _slot = slot;
        }

        public void UseItem()
        {
            if (_slot.IsEmpty)
                return;

            Debug.Log(_slot.Item.Profile.Name);
        }
    }
}