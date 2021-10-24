using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class PlayerInventory : Singleton<PlayerInventory>
    {
        [SerializeField] private int _maxCapacity;
        [SerializeField] private int _initialSlots;

        public Inventory Inventory;

        private void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }

        private void Start()
        {
            Inventory = new Inventory(_maxCapacity, _initialSlots);
        }

        private void OnValidate()
        {
            _maxCapacity = _maxCapacity > _initialSlots ? _maxCapacity : _initialSlots;
        }
    }
}