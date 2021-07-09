using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour
{
    protected static T _instance;
    public static T Instance{
        get{
            if(_instance == null)
                Debug.LogError("No instance for this singleton");
            
            return _instance;
        }

        set => _instance = value;
    }
}
