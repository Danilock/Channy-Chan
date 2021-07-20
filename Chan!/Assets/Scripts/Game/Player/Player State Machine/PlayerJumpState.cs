using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

namespace Game
{
    public class PlayerJumpState : State<PlayerController>
    {
        public override void EnterState(PlayerController entity)
        {
            entity.AttackController.CanAttack = false;
            PlayerAnimations.TriggerJumpAnimation(true);
        }

        public override void ExitState(PlayerController entity)
        {
            //Player cannot attack while jumping
            entity.AttackController.CanAttack = true;

            //Triggers jump animation
            PlayerAnimations.TriggerJumpAnimation(false);
        }

        public override void TickState(PlayerController entity)
        {
            if (entity.CharacterController.IsGrounded && entity.Rigidbody.velocity.y == 0f)
                entity.PlayerMachine.SetState(entity.IdleState);
        }
    }
}