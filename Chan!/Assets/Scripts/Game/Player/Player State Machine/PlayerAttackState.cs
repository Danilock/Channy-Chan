using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

namespace Game
{
    public class PlayerAttackState : State<PlayerController>
    {
        private int _characterIndex = 0;
        private bool _triggeredCharacterKey = false;

        public override void EnterState(PlayerController entity)
        {
            entity.AttackController.CanAttack = false;
            entity.Movement.CanMove = false;
            entity.CharacterHandlerInstance.CanSwitch = false;

            _triggeredCharacterKey = false;
        }

        public override void TickState(PlayerController entity)
        {
            #region Handling Change Character Key
            if (InputHandler.SelectFirstCharacterTriggered)
            {
                _triggeredCharacterKey = true;
                _characterIndex = 0;
            }
            else if (InputHandler.SelectSecondCharacterTriggered)
            {
                _triggeredCharacterKey = true;
                _characterIndex = 1;
            }
            #endregion
        }

        public override void ExitState(PlayerController entity)
        {
            entity.AttackController.CanAttack = true;
            entity.Movement.CanMove = true;
            entity.CharacterHandlerInstance.CanSwitch = true;

            //The attack state checks if the change character key was pressed.
            //This will make the character change once the attack animation finish.
            if (_triggeredCharacterKey)
            {
                entity.CharacterHandlerInstance.ChangeCharacter(_characterIndex);
            }
        }
    }
}