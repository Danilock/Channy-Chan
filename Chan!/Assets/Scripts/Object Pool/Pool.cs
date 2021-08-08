using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    public List<GameObject> PoolObjects = new List<GameObject>();
    private int _currentIndex = 0;

    public GameObject GetObjectInPool
    {
        get
        {
            GameObject objToTake = PoolObjects[_currentIndex];
            objToTake.SetActive(true);

            _currentIndex = (_currentIndex + 1) % PoolObjects.Count;

            return objToTake;
        }
    }
}
