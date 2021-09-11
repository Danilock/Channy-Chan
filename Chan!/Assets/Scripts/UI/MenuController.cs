using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

namespace UI
{
    /// <summary>
    /// Base Class for all UI Menus in game.
    /// </summary>
    public class MenuController : MonoBehaviour
    {
        public bool IsOpen;
        public virtual void OnMenuOpen()
        {
            IsOpen = true;
        }
        public virtual void OnMenuClose()
        {
            IsOpen = false;
        }
    }
}