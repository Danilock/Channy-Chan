using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

namespace Game
{
    public class PlayerIdleState : State<PlayerController>
    {
        public override void EnterState(PlayerController entity)
        {
            
        }

        public override void ExitState(PlayerController entity)
        {
            
        }

        public override void TickState(PlayerController entity)
        {
            if (PlayerMovement.IsMoving)
                entity.PlayerMachine.SetState(entity.WalkState);
            else if (InputHandler.JumpTriggered)
                entity.PlayerMachine.SetState(entity.JumpState);
        }
    }
}