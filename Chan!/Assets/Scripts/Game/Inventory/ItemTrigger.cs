using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class ItemTrigger : MonoBehaviour
    {
        [SerializeField] private Item _item;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                PlayerInventory.Instance.Inventory.AddItem(_item);

                gameObject.SetActive(false);
            }
        }
    }
}