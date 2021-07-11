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

        public Damageable Damageable;
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
                Profile.Portrait
            );

            this.Element = profile.ScriptableElement.Element;
        }
        #endregion
    
        public void SetupCharacter(string name, string description, int damage, int health, Sprite portrait)
        {
            this.Name = name;
            this.Description = description;
            this.Damage = damage;
            this.BaseHealth = health;
            this.Portrait = portrait;
        }
    }
}