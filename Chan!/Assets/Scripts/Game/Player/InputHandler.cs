using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<Summary>
///-----------------------------|Class Ussage|----------------------------
/// The inputhandler class should only be used to reference input actions 
/// by other classes.
///</Summary>
namespace Game
{
    public class InputHandler : Singleton<InputHandler>
    {
        private ChanActions _chanActions;
        ///<Summary>
        /// Gets the vector2 axis of the WASD keys input.
        ///</Summary>
        public static Vector2 MoveVector
        {
            get => Instance._chanActions.Player.Move.ReadValue<Vector2>();
        }

        public static bool JumpTriggered
        {
            get
            {
                return Instance._chanActions.Player.Jump.triggered;
            }
        }

        public static bool SelectFirstCharacterTriggered
        {
            get
            {
                return Instance._chanActions.Player.PickCharacter1.triggered;
            }
        }

        public static bool SelectSecondCharacterTriggered
        {
            get
            {
                return Instance._chanActions.Player.PickCharacter2.triggered;
            }
        }

        private void Awake()
        {
            #region Setup Singleton
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
            {
                _instance = this;
            }
            #endregion

            _chanActions = new ChanActions();
            _chanActions.Enable();
        }
    }
}