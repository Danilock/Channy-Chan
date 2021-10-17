using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Game.Rooms;

namespace GameEditor
{
    [CustomEditor(typeof(RoomController))]
    public class RoomManagerEditor : Editor
    {
        private SerializedProperty _roomsInScene;

        private void OnEnable()
        {
            _roomsInScene = serializedObject.FindProperty("_rooms");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_roomsInScene);

            if (GUILayout.Button("Find Rooms"))
            {
                var t = (target as RoomController);
                t.FindAllRooms();
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}