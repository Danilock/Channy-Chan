using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class Character : MonoBehaviour
    {
        public ScriptableCharacterProfile Profile;

        public LevelEXP CharacterEXP = new LevelEXP();

        #region Character Stats Variables
        public string Name { get; set; }
        public string Description { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        [HideInInspector] public Element Element = new Element();
        public Sprite Portrait { get; set; }
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