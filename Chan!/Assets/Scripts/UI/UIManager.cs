using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI {
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private ItemDescriptionPanel _itemDescriptionPanel;

        private MenuController _currentMenu; 

        public ItemDescriptionPanel GetItemDescriptionPanel
        {
            get => _itemDescriptionPanel;
        }
        
        private void Awake()
        {
            #region Setup Singleton
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            #endregion
        }

        /// <summary>
        /// Sets a new menu on screen.
        /// </summary>
        /// <param name="newMenu"></param>
        public void SetMenu(MenuController newMenu)
        {
            _currentMenu?.OnMenuClose();

            _currentMenu = newMenu;

            _currentMenu?.OnMenuOpen();
        }
    }
}