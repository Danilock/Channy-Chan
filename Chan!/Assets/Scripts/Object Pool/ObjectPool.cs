using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ObjectPool : Singleton<ObjectPool>
    {
        private Dictionary<string, List<GameObject>> PoolManager;

        private void Awake()
        {
            if (_instance != this && _instance != null)
                Destroy(this.gameObject);
            else
            {
                _instance = this;
                //DontDestroyOnLoad(this.gameObject);
            }

            PoolManager = new Dictionary<string, List<GameObject>>();
        }

        /// <summary>
        /// Generates a pool and add it to the PoolManager.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="obj"></param>
        /// <param name="amount"></param>
        public void GeneratePool(string name, GameObject obj, int amount)
        {
            List<GameObject> objList = new List<GameObject>();

            for (int i = 0; i < amount; i++)
            {
                GameObject currentObj = Instantiate(obj);

                currentObj.SetActive(false);
                objList.Add(currentObj);
            }

            PoolManager.Add(name, objList);
        }
    }
}