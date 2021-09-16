using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Rooms
{
    public class RoomController : Singleton<RoomController>
    {
        [SerializeField] private List<Room> _rooms = new List<Room>();

        private Room _currentRoom;

        public Room CurrentRoom
        {
            get => _currentRoom;
            private set => _currentRoom = value;
        }

        private void Awake()
        {
            #region Setup Singleton
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
                _instance = this;
            #endregion
        }

        private void Start()
        {
            PickRoom(_rooms[0]);
        }

        public void PickRoom(Room newRoom)
        {
            CurrentRoom?.DesactivateRoom();

            CurrentRoom = newRoom;

            CurrentRoom.ActivateRoom();
        }

        [ContextMenu("Find Rooms")]
        private void FindAllRooms()
        {
            _rooms.Clear();

            var rooms = FindObjectsOfType<RoomBehaviour>();

            foreach(var room in rooms)
            {
                _rooms.Add(room.GetRoom);
            }
        }
    }
}