using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;

namespace InventorySystem
{
    /// <summary>
    /// Used to create ScriptableProfiles for Items
    /// </summary>
    [CreateAssetMenu(fileName = "Item", menuName = "Inventory/Create Item")]
    public class ItemData : ScriptableObject
    {
        public Sprite Portrait;
        public string Name;
        [TextArea] public string Description;

        [Space, Header("Usage")]
        public ItemUsage Usage;
        public bool IsStackableOnInventory = true;

        [Space, Header("Buff Duration")]
        public BuffDurationType DurationType;
        public int BuffDuration;

        [Space, Header("Modifiers")]
        public int AddHealth;
        public int AddDamage;

        [Space(5), Header("Localization")]
        public LocalizedString LocalizedItemDescription;
    }

    public enum ItemUsage
    {
        ToAllCharacters,
        ToCurrentCharacter
    }

    public enum BuffDurationType
    {
        Temporaly,
        Infinite
    }
}