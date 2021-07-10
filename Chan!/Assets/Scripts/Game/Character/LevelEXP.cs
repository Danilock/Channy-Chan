using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    /// <summary>
    /// ---------------------------|Class Info|---------------------------
    /// Class used to represent exp data.
    /// ------------------------------------------------------------------
    /// </summary>
    [System.Serializable]
    public class LevelEXP
    {
        [Header("Level")]
        public int CurrentLevel = 1;
        public int MaxLevel = 20;

        [Header("EXP")]
        public float CurrentEXP;
        public float RequiredEXP = 100; // Required exp to get to other level.

        public UnityEvent OnUpgradeLevel;

        public void GainExp(float value)
        {
            if (CurrentLevel == MaxLevel)
                return;

            CurrentEXP += value;

            if(CurrentEXP >= RequiredEXP)
            {
                UpgradeLevelBasedOnCurrentEXP();
            }
        }

        private void UpgradeLevelBasedOnCurrentEXP()
        {
            if(CurrentEXP > RequiredEXP)
            {
                RequiredEXP *= 2f;

                CurrentLevel += 1;

                OnUpgradeLevel.Invoke();

                UpgradeLevelBasedOnCurrentEXP();
            }
        }
    }
}