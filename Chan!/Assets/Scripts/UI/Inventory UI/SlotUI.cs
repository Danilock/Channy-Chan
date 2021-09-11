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
        private Slot _slot = new Slot();

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
            _itemImage.sprite = slot.Item.Profile.Portrait;
            _itemAmount.text = $"{slot.Item.Amount}";

            _slot = slot;

            _stringEvent.StringReference = _slot.Item.Profile.LocalizedItemDescription;
        }

        public void UseItem()
        {
            if (_slot.IsEmpty)
                return;

            Debug.Log(_slot.Item.Profile.Name);
        }
    }
}