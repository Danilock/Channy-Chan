using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Rooms
{
    public class DoorTrigger : MonoBehaviour
    {
        [SerializeField] private RoomBehaviour _roomToPick;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Player"))
                return;

            RoomController.Instance.PickRoom(_roomToPick.GetRoom);
        }

        private void OnValidate()
        {
            _roomToPick = GetComponentInParent<RoomBehaviour>();
        }
    }
}