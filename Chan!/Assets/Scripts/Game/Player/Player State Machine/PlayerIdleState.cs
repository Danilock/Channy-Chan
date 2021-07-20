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
            //If is moving, then changes to the walk state.
            if (PlayerMovement.IsMoving)
                entity.PlayerMachine.SetState(entity.WalkState);
            //If the jump key is triggered, then changes to jump state.
            else if (InputHandler.JumpTriggered)
                entity.PlayerMachine.SetState(entity.JumpState);
        }
    }
}