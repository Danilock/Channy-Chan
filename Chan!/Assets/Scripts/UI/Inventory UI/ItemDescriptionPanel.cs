using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

namespace UI
{
    public class ItemDescriptionPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _itemDescription;

        // Update is called once per frame
        void Update()
        {
            transform.position = Mouse.current.position.ReadValue();
        }

        public void SetDescriptionText(string text) => _itemDescription.text = text;
    }
}