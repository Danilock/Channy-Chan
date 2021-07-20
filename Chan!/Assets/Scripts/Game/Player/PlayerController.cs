using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

/// -------------------------|Class Description|-----------------------------
///<Summary>
/// Class that will be like an orchestor between all the player systems like 
/// input, character handler, state machine etc.
/// Note: This class should only exist once per scene.  
///</Summary>
/// -------------------------------------------------------------------------
///
namespace Game
{
    public class PlayerController : Singleton<PlayerController>
    {
        #region Player State Machine
        public StateMachine<PlayerController> PlayerMachine;
        public PlayerIdleState IdleState = new PlayerIdleState();
        public PlayerWalkState WalkState = new PlayerWalkState();
        public PlayerJumpState JumpState = new PlayerJumpState();
        public PlayerAttackState AttackState = new PlayerAttackState();
        public PlayerLandState LandState = new PlayerLandState();
        #endregion

        #region CharacterController2D
        private CharacterController2D _ch2D;
        public CharacterController2D CharacterController
        {
            get => _ch2D;
            private set => _ch2D = value;
        }
        #endregion

        #region External Components
        private CharacterHandler _characterHandler;
        public Rigidbody2D Rigidbody
        {
            get => _ch2D.Rgb2D;
        }

        public Animator CurrentCharacterAnimator
        {
            get => _characterHandler.CurrentCharacter.Animator;
        }
        public PlayerAnimations PlayerAnimationsHandler;

        public PlayerAttackController AttackController;
        public PlayerMovement Movement;
        #endregion
        private void Awake()
        {
            #region Singleton
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
            {
                _instance = this;
            }
            #endregion

            PlayerMachine = new StateMachine<PlayerController>(this);

            #region Get Components
            PlayerAnimationsHandler = GetComponent<PlayerAnimations>();
            AttackController = GetComponent<PlayerAttackController>();
            Movement = GetComponent<PlayerMovement>();
            _ch2D = GetComponent<CharacterController2D>();
            _characterHandler = GetComponent<CharacterHandler>();
            #endregion
        }


        private void Start()
        {
            //Set the idleState as initial state.
            PlayerMachine.SetState(IdleState);
        }

        private void Update()
        {
            //Current state is running on it's tick state.
            PlayerMachine.CurrentState.TickState(this);
        }
        
        /// <summary>
        /// Sets a player state based on enums.
        /// </summary>
        /// <param name="newState"></param>
        public void SetPlayerStateByEnum(PlayerStates newState)
        {
            switch (newState)
            {
                case PlayerStates.IdleState:
                    PlayerMachine.SetState(IdleState);
                    break;

                case PlayerStates.JumpState:
                    PlayerMachine.SetState(JumpState);
                    break;

                case PlayerStates.WalkState:
                    PlayerMachine.SetState(WalkState);
                    break;

                case PlayerStates.AttackState:
                    PlayerMachine.SetState(AttackState);
                    break;

                case PlayerStates.LandState:
                    PlayerMachine.SetState(LandState);
                    break;
            }
        }
    }
}

public enum PlayerStates
{
    IdleState,
    WalkState,
    JumpState,
    AttackState,
    LandState
}