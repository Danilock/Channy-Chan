using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Rooms
{
    public class RoomBehaviour : MonoBehaviour
    {
        [SerializeField] private Room _room;

        public Room GetRoom
        {
            get => _room;
        }
    }
}