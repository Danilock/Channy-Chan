using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class Character : MonoBehaviour
    {
        public ScriptableCharacterProfile Profile;

        public LevelEXP CharacterEXP = new LevelEXP();

        #region Character Stats Variables
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Damage { get; private set; }
        public int Health { get; private set; }
        [HideInInspector] public Element Element = new Element();
        public Sprite Portrait { get; set; }

        [SerializeField] private Animator _animator;
        public Animator Animator
        {
            get => _animator;
        }
        #endregion

        public AbilityComponent Ability;

        private void Start()
        {
            //TODO: Check if there's a saved profile for this character to setup.

            SetupCharacter(Profile);
        }

        public void SetupCharacter(ScriptableCharacterProfile profile)
        {
            if (profile == null)
                return;

            this.Name = profile.Name;
            this.Description = profile.Description;
            this.Damage = profile.BaseDamage;
            this.Health = profile.BaseHealth;
            this.Element = profile.ScriptableElement.Element;
            this.Portrait = profile.Portrait;
        }
    }
}