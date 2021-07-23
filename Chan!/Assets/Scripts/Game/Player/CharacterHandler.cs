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

        private Character _lastCharacter;
        public Character LastCharacter
        {
            get => _lastCharacter;
            private set => _lastCharacter = value;
        }

        /// <summary>
        /// Invoked once the player change characters. Returns the current character and the last character.
        /// </summary>
        public UnityEvent<Character> OnChangeCharacter;

        [Header("Switch Control")]
        [SerializeField] private float _switchCooldown;
        [SerializeField] private bool _canSwitch = true;

        public bool CanSwitch
        {
            get => _canSwitch;
            set => _canSwitch = value;
        }

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

            if (CurrentCharacter != null)
                LastCharacter = CurrentCharacter;

            HandleCharacterActivation(CurrentCharacter, false);

            CurrentCharacter = _characters[index];

            CurrentCharacter.gameObject.SetActive(true);

            HandleCharacterActivation(CurrentCharacter, true);

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
                HandleCharacterActivation(currentCharacter, false);
            }

            ChangeCharacter(0);
        }

        /// <summary>
        /// Makes a character visible or not depending on the state passed as a parameter.
        /// </summary>
        /// <param name="ch"></param>
        /// <param name="state"></param>
        public void HandleCharacterActivation(Character ch, bool state)
        {
            if (ch == null)
                return;

            ch.Renderer.enabled = state;
            ch.Collider.enabled = state;
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