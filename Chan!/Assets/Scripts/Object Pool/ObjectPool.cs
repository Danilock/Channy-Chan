using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Game
{
    public class ObjectPool : Singleton<ObjectPool>
    {
        private Dictionary<string, Pool> PoolManager;

        private void Awake()
        {
            if (_instance != this && _instance != null)
                Destroy(this.gameObject);
            else
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }

            PoolManager = new Dictionary<string, Pool>();
        }

        /// <summary>
        /// Generates a pool and add it to the PoolManager.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="obj"></param>
        /// <param name="amount"></param>
        public void GeneratePool(string name, GameObject obj, int amount)
        {
            //Generates an empty pool
            Pool newPool = new Pool();

            //Generates a parent object for this pool
            GameObject gm = new GameObject("Pool " + name);

            //Generates each object based on the amount value
            for (int i = 0; i < amount; i++)
            {
                GameObject currentObj = Instantiate(obj);

                currentObj.SetActive(false);
                currentObj.transform.SetParent(gm.transform);

                newPool.PoolObjects.Add(currentObj);
            }

            //Adds the pool to the pool manager
            PoolManager.Add(name, newPool);
        }

        /// <summary>
        /// Returns an object in the pool specified.
        /// </summary>
        /// <param name="poolName"></param>
        /// <returns></returns>
        public GameObject GetObjectInPool(string poolName)
        {
            return PoolManager[poolName].GetObjectInPool;
        }
    }
}