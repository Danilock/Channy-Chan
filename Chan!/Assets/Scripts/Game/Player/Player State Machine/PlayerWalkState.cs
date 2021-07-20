using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

namespace Game
{
    public class PlayerWalkState : State<PlayerController>
    {
        public override void EnterState(PlayerController entity)
        {
            PlayerAnimations.TriggerWalkAnimation(true);
        }

        public override void ExitState(PlayerController entity)
        {
            PlayerAnimations.TriggerWalkAnimation(false);
        }

        public override void TickState(PlayerController entity)
        {
            //Returns to idle state.
            if (!PlayerMovement.IsMoving)
                entity.PlayerMachine.SetState(entity.IdleState);
            else if (InputHandler.JumpTriggered)
                entity.PlayerMachine.SetState(entity.JumpState);
        }
    }
}