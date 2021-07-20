using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

namespace Game
{
    public class PlayerLandState : State<PlayerController>
    {
        public override void EnterState(PlayerController entity)
        {
            entity.AttackController.CanAttack = true;
            entity.Movement.CanMove = false;
            entity.Rigidbody.velocity /= 2; 
        }

        public override void ExitState(PlayerController entity)
        {
            entity.Movement.CanMove = true;
        }
    }
}