using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InventorySystem;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Localization.Components;

namespace UI
{
    public class SlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _itemImage;
        [SerializeField] private TMP_Text _itemAmount;
        [SerializeField] private LocalizeStringEvent _stringEvent;

        [Header("On Empty")]
        [SerializeField] private Sprite _emptyCellImage;

        private Slot _slot = new Slot();

        public Slot GetSlot
        {
            get => _slot;
        }

        public Item GetItemInSlot
        {
            get => _slot.Item;
        }

        private string _localizedDescription;
        public string LocalizedDescription
        {
            get => _localizedDescription;
            set
            {
                _localizedDescription = value;
            }
        }

        private void Awake()
        {
            _stringEvent = GetComponent<LocalizeStringEvent>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_slot.IsEmpty)
                return;

            //Actiavtes the item description panel
            UIManager.Instance.GetItemDescriptionPanel.gameObject.SetActive(true);
            
            //Sets the description 
            UIManager.Instance.GetItemDescriptionPanel.SetDescriptionText
                (LocalizedDescription == null ?
                _slot.Item.Profile.Description : 
                LocalizedDescription);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_slot.IsEmpty)
                return;

            UIManager.Instance.GetItemDescriptionPanel.gameObject.SetActive(false);
        }

        public void UpdateSlotData(Slot slot)
        {
            if (slot.IsEmpty)
            {
                _itemImage.sprite = _emptyCellImage;
                _itemAmount.text = "";

                return;
            }

            _itemImage.sprite = slot.Item.Profile.Portrait;
            _itemAmount.text = $"{slot.Item.Amount}";

            _slot = slot;

            _stringEvent.StringReference = _slot.Item.Profile.LocalizedItemDescription;
        }

        public void UseItem()
        {
            if (_slot.IsEmpty)
                return;

            _slot.UseItem();
            UpdateSlotData(_slot);

            if (_slot.IsEmpty)
                UIManager.Instance.GetItemDescriptionPanel
                    .gameObject.SetActive(false);
        }
    }
}