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
        [SerializeField] private List<CharacterInstance> _characters;

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

            CurrentCharacter = _characters[index];

            Debug.Log(CurrentCharacter.Name);

            OnChangeCharacter?.Invoke(CurrentCharacter);

            StartCoroutine(HandleSwitchCooldown());
        }

        public void AddCharacter(CharacterInstance newCharacter)
        {
            _characters.Add(newCharacter);
        }

        /// <summary>
        /// Initialize the list to avoid null references.
        /// </summary>
        private void InitializeCharacterList()
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                _characters[i] = new CharacterInstance(_characters[i].Profile);
            }
        }

        /// <summary>
        /// Sets the CanSwitch bool variable in x seconds.
        /// </summary>
        /// <returns></returns>
        private IEnumerator HandleSwitchCooldown()
        {
            _canSwitch = false;
            yield return new WaitForSeconds(_switchCooldown);
            _canSwitch = true;
        }
    }
}