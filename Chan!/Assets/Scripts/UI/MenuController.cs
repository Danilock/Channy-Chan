using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

namespace UI
{
    /// <summary>
    /// Base Class for all UI Menus in game.
    /// </summary>
    public abstract class MenuController : MonoBehaviour
    {
        public abstract void OnMenuOpen();
        public abstract void OnMenuClose();
    }
}