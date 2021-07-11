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
        public Animator Animator { get; set; }
        private CharacterHandler _characterHandler;
        private SpriteRenderer _spriteRenderer;
        private DamageableComponent _damageable;
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
            _ch2D = GetComponent<CharacterController2D>();
            _characterHandler = GetComponent<CharacterHandler>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _damageable = GetComponent<DamageableComponent>();
            #endregion

            _characterHandler.OnChangeCharacter.AddListener(UpdatePlayerPropertiesOnSwitchCharacter);
        }

        private void Start()
        {
            PlayerMachine.SetState(IdleState);
        }

        private void Update()
        {
            PlayerMachine.CurrentState.TickState(this);
        }

        /// <summary>
        /// Change all the player properties to the character passed as a parameter.
        /// </summary>
        /// <param name="character"></param>
        public void UpdatePlayerPropertiesOnSwitchCharacter(CharacterInstance character)
        {
            _spriteRenderer.sprite = character.Portrait;

            Debug.Log(character.Element.Name);
        }
    }
}