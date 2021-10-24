using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Game.Rooms
{
    [System.Serializable]
    public class Room
    {
        [SerializeField] private CinemachineVirtualCamera _cvm;

        [SerializeField] private List<DoorTrigger> _doors;

        public CinemachineVirtualCamera GetVirtualCamera
        {
            get => _cvm;
        }

        public void ActivateRoom()
        {
            _cvm.gameObject.SetActive(true);

            SetDoorsActive(false);
        }

        public void DesactivateRoom()
        {
            _cvm.gameObject.SetActive(false);

            SetDoorsActive(true);
        }

        private void SetDoorsActive(bool state)
        {
            foreach(DoorTrigger currentDoor in _doors)
            {
                currentDoor.gameObject.SetActive(state);
            }
        }
    }
}