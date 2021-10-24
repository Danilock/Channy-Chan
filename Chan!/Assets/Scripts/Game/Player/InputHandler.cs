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
    [DisallowMultipleComponent]
    public class InputHandler : Singleton<InputHandler>
    {
        private ChanActions _chanActions;
        public static ChanActions GetChanActions
        {
            get => Instance._chanActions;
        }
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

        public static bool PauseTriggered
        {
            get => Instance._chanActions.Player.Pause.triggered;
        }

        public static bool CloseMenuTriggered
        {
            get => Instance._chanActions.UI.Cancel.triggered;
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

        public static bool InventoryTriggered
        {
            get => Instance._chanActions.Player.InventoryKey.triggered;
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

        public static void EnableUIInput() => Instance._chanActions.UI.Enable();

        public static void DisableUIInput() => Instance._chanActions.UI.Disable();

        public static void EnablePlayerInput() => Instance._chanActions.Player.Enable();

        public static void DisablePlayerInput() => Instance._chanActions.Player.Disable();
    }
}