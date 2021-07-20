using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

namespace Game
{
    public class PlayerAttackState : State<PlayerController>
    {
        public override void EnterState(PlayerController entity)
        {
            entity.AttackController.CanAttack = false;
            entity.Movement.CanMove = false;
        }

        public override void ExitState(PlayerController entity)
        {
            entity.AttackController.CanAttack = true;
            entity.Movement.CanMove = true;
        }
    }
}