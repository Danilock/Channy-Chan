using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines a character instance with it's animator
/// </summary>
namespace Game
{
    [System.Serializable]
    public class CharacterInstance
    {
        public ScriptableCharacterProfile Profile;

        public LevelEXP CharacterEXP = new LevelEXP();

        #region Character Stats Variables
        public string Name { get; set; }
        public string Description { get; set; }
        public int Damage { get; set; }
        public int BaseHealth { get; set; }
        public Element Element = new Element();
        public Sprite Portrait { get; set; }

        public Damageable Damageable = new Damageable();
        #endregion


        #region Construtors
        public CharacterInstance() { }

        public CharacterInstance(ScriptableCharacterProfile profile)
        {
            Profile = profile;

            SetupCharacter
            (
                Profile.name,
                Profile.Description,
                Profile.BaseDamage,
                Profile.BaseHealth,
                Profile.ScriptableElement.Element,
                Profile.Portrait
            );

            Damageable.CurrentHealth = BaseHealth;
            Damageable.ScriptableElement = profile.ScriptableElement;
        }
        #endregion
    
        public void SetupCharacter(string name, string description, int damage, int health, Element element, Sprite portrait)
        {
            this.Name = name;
            this.Description = description;
            this.Damage = damage;
            this.BaseHealth = health;
            this.Element = element;
            this.Portrait = portrait;
        }
    }
}