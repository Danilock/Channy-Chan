using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<Summary>
///-----------------------------|Class Ussage|----------------------------
/// The inputhandler class should only be used to reference input actions 
/// by other classes.
///</Summary>
public class InputHandler : Singleton<InputHandler>
{
    private ChanActions _chanActions;
    ///<Summary>
    /// Gets the vector2 axis of the WASD keys input.
    ///</Summary>
    public static Vector2 MoveVector{
        get => Instance._chanActions.Player.Move.ReadValue<Vector2>();
    }

    private void Awake() {
        #region Setup Singleton
        if(_instance != null && _instance != this)
            Destroy(this.gameObject);
        else{
            _instance = this;
        }
        #endregion

        _chanActions = new ChanActions();
        _chanActions.Enable();
    }
}
