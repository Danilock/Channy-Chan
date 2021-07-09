using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<Summary>
/// -------------------------|Class Description|-----------------------------
/// Class that will be like an orchestor between all the player systems like 
/// input, character handler, state machine etc.
/// -------------------------------------------------------------------------
/// Note: This class should only exist once per scene.  
///</Summary>
public class PlayerController : Singleton<PlayerController>
{
    private void Awake() {
        if(_instance != null && _instance != this)
            Destroy(this.gameObject);
        else{
            _instance = this;
        }
    }
}
