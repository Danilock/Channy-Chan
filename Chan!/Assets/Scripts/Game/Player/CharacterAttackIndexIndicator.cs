using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Should be only attached to characters under the control of the player.
    /// Set how many basic attacks the character has.
    /// </summary>
    public class CharacterAttackIndexIndicator : MonoBehaviour
    {
        [SerializeField] private int _attacksAllowed = 3;

        public int GetAttacksAllowed
        {
            get => _attacksAllowed;
        }
    }
}