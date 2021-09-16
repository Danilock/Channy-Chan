using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

namespace UI {
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private ItemDescriptionPanel _itemDescriptionPanel;

        [Header("Menus References")]
        [SerializeField] private InventoryUI _inventoryUI;

        private List<MenuController> _openMenus = new List<MenuController>(); 

        public ItemDescriptionPanel GetItemDescriptionPanel
        {
            get => _itemDescriptionPanel;
        }
        
        public MenuController GetCurrentMenu
        {
            get => _openMenus[_openMenus.Count - 1];
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

        private void Update()
        {
            if (InputHandler.InventoryTriggered)
                OpenMenu(_inventoryUI);


            if (InputHandler.CloseMenuTriggered)
                CloseMenu(GetCurrentMenu);
        }

        /// <summary>
        /// Open the given menu.
        /// </summary>
        /// <param name="menuToOpen"></param>
        private void OpenMenu(MenuController menuToOpen)
        {
            //If there's any menu opened we disable player interactions
            if (_openMenus.Count == 0)
            {
                InputHandler.DisablePlayerInput();
                InputHandler.EnableUIInput();
            }

            _openMenus.Add(menuToOpen);

            menuToOpen.OnMenuOpen();
        }

        /// <summary>
        /// Close the given menu.
        /// </summary>
        /// <param name="menuToClose"></param>
        private void CloseMenu(MenuController menuToClose)
        {
            _openMenus.Remove(menuToClose);

            menuToClose.OnMenuClose();

            //If all menus are close we disable UI interactions
            if(_openMenus.Count == 0)
            {
                InputHandler.DisableUIInput();
                InputHandler.EnablePlayerInput();
            }
        }
    }
}