using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class PlayerAnimationHandler : StateMachineBehaviour
    {
        [SerializeField] private PlayerStates OnEnterAnimState, OnExitAnimState;
        private PlayerController _player;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _player = FindObjectOfType<PlayerController>();

            _player.SetPlayerStateByEnum(OnEnterAnimState);
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _player.SetPlayerStateByEnum(OnExitAnimState);
        }
    }
}