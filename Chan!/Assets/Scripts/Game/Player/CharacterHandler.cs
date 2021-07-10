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
        [SerializeField] private List<CharacterInstance> _characters = new List<CharacterInstance>();

        private CharacterInstance _currentCharacter;
        /// <summary>
        /// Gets the current character.
        /// </summary>
        public CharacterInstance CurrentCharacter
        {
            get => _currentCharacter;
            private set => _currentCharacter = value;
        }

        public UnityEvent<CharacterInstance> OnChangeCharacter;

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
            CurrentCharacter = _characters[index];

            OnChangeCharacter?.Invoke(CurrentCharacter);
        }

        public void AddCharacter(CharacterInstance newCharacter)
        {
            _characters.Add(newCharacter);
        }
    }
}