using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class PlayerAnimationHandler : StateMachineBehaviour
    {
        [SerializeField] private PlayerStates OnEnterAnimState, OnExitAnimState;
        private PlayerController _player;

        // Sets the player state to OnEnterAnimState.
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _player = FindObjectOfType<PlayerController>();

            _player.SetPlayerStateByEnum(OnEnterAnimState);
        }

        // Sets the player state to OnExitAnimState.
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _player.SetPlayerStateByEnum(OnExitAnimState);
        }
    }
}