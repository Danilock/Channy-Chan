using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Rooms
{
    public class RoomController : Singleton<RoomController>
    {
        [SerializeField] private List<Room> _rooms = new List<Room>();
        [SerializeField] private float _fadeTime = 1f;

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

        public void PickRoom(Room newRoom) => StartCoroutine(ProcessRoom(newRoom));

        private IEnumerator ProcessRoom(Room newRoom)
        {
            Time.timeScale = 0f;

            CurrentRoom?.DesactivateRoom();

            CurrentRoom = newRoom;

            CurrentRoom.ActivateRoom();

            yield return new WaitForSecondsRealtime(_fadeTime);

            Time.timeScale = 1f;
        }

        [ContextMenu("Find Rooms")]
        public void FindAllRooms()
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