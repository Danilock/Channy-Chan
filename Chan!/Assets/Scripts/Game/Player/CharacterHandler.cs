using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

/// <summary>
/// ----------------------------------|Class Info|--------------------------------
/// This class should be used to handle the characters in current player's party.
/// ------------------------------------------------------------------------------
/// </summary>
namespace Game
{
    public class CharacterHandler : MonoBehaviour
    {
        [SerializeField] private List<Character> _characters;

        private Character _currentCharacter;
        /// <summary>
        /// Gets the current character.
        /// </summary>
        public Character CurrentCharacter
        {
            get => _currentCharacter;
            private set => _currentCharacter = value;
        }

        public UnityEvent<Character> OnChangeCharacter;

        [Header("Switch Control")]
        [SerializeField] private float _switchCooldown;
        [SerializeField] private bool _canSwitch = true;

        private void Start()
        {
            InitializeCharacterList();
        }

        private void Update()
        {
            if (InputHandler.SelectFirstCharacterTriggered)
                ChangeCharacter(0);
            else if (InputHandler.SelectSecondCharacterTriggered)
                ChangeCharacter(1);
        }

        /// <summary>
        /// Change a character based on the index received.
        /// </summary>
        /// <param name="index">The index should be inside the bounds</param>
        public void ChangeCharacter(int index)
        {
            if (!_canSwitch)
                return;

            if(CurrentCharacter == _characters[index])
            {
                //TODO: Make error sound
                return;
            }

            CurrentCharacter?.gameObject.SetActive(false);

            CurrentCharacter = _characters[index];

            CurrentCharacter.gameObject.SetActive(true);

            OnChangeCharacter?.Invoke(CurrentCharacter);

            StartCoroutine(HandleSwitchCooldown());
        }

        /// <summary>
        /// Adds a character to the characters list.
        /// </summary>
        /// <param name="newCharacter"></param>
        public void AddCharacter(Character newCharacter)
        {
            
        }

        private void InitializeCharacterList()
        {
            foreach(Character currentCharacter in _characters)
            {
                currentCharacter.gameObject.SetActive(false);
            }

            ChangeCharacter(0);
        }

        /// <summary>
        /// Sets the CanSwitch bool variable in x seconds.
        /// </summary>
        /// <returns></returns>
        private IEnumerator HandleSwitchCooldown()
        {
            _canSwitch = false;
            yield return new WaitForSecondsRealtime(_switchCooldown);
            _canSwitch = true;
        }
    }
}