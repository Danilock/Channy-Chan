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
        public int Health { get; set; }
        public Element Element;
        public Sprite Portrait { get; set; }
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
                Profile.Element,
                Profile.Portrait
            );
        }
        #endregion
    
        public void SetupCharacter(string name, string description, int damage, int health, Element element, Sprite portrait)
        {
            this.Name = name;
            this.Description = description;
            this.Damage = damage;
            this.Health = health;
            this.Element = element;
            this.Portrait = portrait;
        }
    }
}